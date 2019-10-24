using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Andamios.API.Helpers;
using Andamios.API.Models;
using Andamios.API.Services.Contracts;
using Andamios.API.Services.Token;
using Andamios.Core.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Andamios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        // Injections 
        private readonly IUsuarioService _usuarioService;
        private UserManager<Usuario> _userManger;
        private SignInManager<Usuario> _signInManger;
        private ApplicationSettings _appSettings;
        private AndamiosDominicanosContext _context;
        private readonly ITokenService _tokenService;

        // Inicialization
        public UsuarioController(IUsuarioService usuarioService,
            UserManager<Usuario> userManger,
            AndamiosDominicanosContext context,
            SignInManager<Usuario> signInManger,
            ITokenService tokenService,
            IOptions<ApplicationSettings> appSettings)
        {
            _usuarioService = usuarioService;
            _signInManger = signInManger;
            _userManger = userManger;
            _appSettings = appSettings.Value;
            _context = context;
            _tokenService = tokenService;
        }

        [HttpGet]
        [Route("ListaUsuarios")]
        public async Task<ActionResult<Usuario>> Get()
        {
            var usuarios =
                await _usuarioService
                    .ListaUsuariosAsync();
                
            
            if (usuarios.Count == 0)
            {
                return NotFound();
            }
            
            return Ok(usuarios);
        }

        // GET api/Usuario/{id}
        [HttpGet("{id}", Name = "VerUsuario")]
        public async Task<ActionResult<Usuario>> Get(string id)
        {
            var usuario = await _usuarioService.GetOneUsuarioAsync(id);

            if (usuario != null)
            {
                return Ok(usuario);
            }

            return NotFound(id);
        }

        // POST /api/user/register
        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult> Post(RegisterViewModel model)
        {
            var user = new Usuario()
            {

                UserName = model.UserName.ToLower(),
                Email = model.Email,
                Nombre = model.Nombre,
                Apellido = model.Apellido,
                Role = model.Role,
                Imagen = model.Imagen

            };

            try
            {
                
                var result = await _userManger.CreateAsync(user, model.Password);

                if(result.Succeeded){

                    return Ok(result);

                }

                return BadRequest();



            }
            catch (Exception e)
            {
                throw e;
            }

        }

        [HttpPut]
        [Route("Editar")]
        public async Task<ActionResult> Edit(Usuario user)
        {
            var result = await _userManger.UpdateAsync(user);

            if(result.Succeeded)
            {
                return Ok(result);
            }else{

                return BadRequest();
            
            }
        }

        

        [HttpPost]
        [Route("Login")]
        // POST /api/user/login
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            var user = new Usuario();

            if(!model.Email.Contains("@"))
            {
              user = await _userManger.FindByNameAsync(model.Email);

            }else{
                user = await _userManger.FindByEmailAsync(model.Email);
            }

            if (user != null && await _userManger.CheckPasswordAsync(user, model.Password))
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secrete));
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[] {
                        new Claim ("UserID", user.Id)
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256)

                };

                var tknHdlr = new JwtSecurityTokenHandler();
                var tokenSecurity = tknHdlr.CreateToken(tokenDescriptor);


                var token = tknHdlr.WriteToken(tokenSecurity);

                var refreshToken = _tokenService.GenerateRefreshToken();

                user.RefreshToken = refreshToken;

                await _usuarioService.SaveOneUsuarioAsync(user);

                return Ok(new { token = token, refreshToken = refreshToken });

            }

            return BadRequest(new { message = "Email or passwrod is incorrect" });

        }



        private ClaimsPrincipal GetPrincipalFromExpiredToken(string tkn)
        {
            var tokenValidationParameters = new TokenValidationParameters()
            {
                ValidateAudience = false, //true si es necesario validar la audiencia o el editor (issuer)
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secrete)),
                ValidateLifetime = false

            };

            var tknhdlr = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tknhdlr.ValidateToken(tkn, tokenValidationParameters, out securityToken);
            var jwtSecutoryToken = securityToken as JwtSecurityToken;

            if (jwtSecutoryToken == null || !jwtSecutoryToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
                    StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Token Inválido!");
            }

            return principal;
        }

        [HttpPost]
        public async Task<IActionResult> Refresh(string token, string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(token);
            var username = principal.Identity.Name;
            var user = _context.Usuarios.FirstOrDefault(x => x.UserName == username); //retrieve the refresh token from a data store
            if (user == null || user.RefreshToken != refreshToken) return BadRequest();

            var newJwtToken = _tokenService.GenerateAccessToken(principal.Claims);
            var newRefreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = newRefreshToken;
            await _usuarioService.SaveOneUsuarioAsync(user);

            return new ObjectResult(new
            {
                token = newJwtToken,
                refreshToken = newRefreshToken
            });
        }

        [HttpPost, Authorize]
        public async Task<IActionResult> Revoke()
        {
            var username = User.Identity.Name;

            var user = _context.Usuarios.FirstOrDefault(x => x.UserName == username); //retrieve the refresh token from a data store

            if (user == null) return BadRequest();

            user.RefreshToken = null;

            await _usuarioService.SaveOneUsuarioAsync(user);

            return NoContent();
        }

        [HttpPost]
        [Route("CambiarEstado")]
        public async Task<ActionResult> ChangeState(string id)
        {
            Usuario user = await _usuarioService.GetOneUsuarioAsync(id);

            if(user != null){

                user.Estado = !user.Estado;

                var result = await _userManger.UpdateAsync(user);

                if(result.Succeeded)
                {
                    return Ok(user);        
                }
                
                return BadRequest();

            }

            return NotFound(id);

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {

            var user = await _userManger.FindByEmailAsync(model.Email);

            if (user == null)
            {
                // Don't reveal that the user does not exist
                return NotFound();
            }
            var result = await _userManger.ResetPasswordAsync(user, model.Code, model.Password);

            if (result.Succeeded)
            {
                return Ok();
            }

            return BadRequest();
        }



    }
}