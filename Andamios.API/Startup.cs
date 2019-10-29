using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Andamios.API.Helpers;
using Andamios.API.Services.Contracts;
using Andamios.API.Services.Repository;
using Andamios.API.Services.Token;
using Andamios.Core.Data.Entities;
using Andamios.Core.Repository.Implementations;
using Andamios.Core.Repository.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Andamios.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            
            // Injection AppSettings.json
            services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddDbContext<AndamiosDominicanosContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AndamiosDominicanosContext")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            // BEGIN SWAGGER
            services.AddSwaggerGen(Configuration => {
                Configuration.SwaggerDoc("v1", new Info()
                {
                    Title = "AndamiosAPI"
                });

                Configuration.ResolveConflictingActions(api => api.First());
            });
            // END SEAGGER

            services.AddDefaultIdentity<Usuario>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<AndamiosDominicanosContext>();

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
            });

            services.AddCors();

            // JWT Validation

            var key = Encoding.UTF8.GetBytes(Configuration["ApplicationSettings:JWT_Secrete"].ToString());

            services.AddAuthentication(x => {

                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(x => {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidIssuer = "http://localhost:53870",
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };

                x.Events = new JwtBearerEvents
                {
                    OnAuthenticationFailed = context =>
                    {
                        if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.Headers.Add("Token-Expired", "true");
                        }
                        return Task.CompletedTask;
                    }
                };
            });

            services.AddHttpClient("Client", client => {

            }).ConfigurePrimaryHttpMessageHandler( () => {
                var handler = new HttpClientHandler();
                //hacer verificacion del entorno (produccion o desarrollo)
                handler.ServerCertificateCustomValidationCallback = 
                (message, cert, chain, errors) => { 

                    return true;
                    
                    } ;

                    return handler;
            });

            #region DIS 

            //services.Configure<ApplicationSettings>(Configuration.GetSection("ApplicationSettings"));

            services.AddScoped<IAutoresService, AutoresService>();
            services.AddScoped<IAutores, AutoresRepository>();

            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            services.AddScoped<IClienteServices, ClienteServices>();
            services.AddScoped<IClienteRepository, ClienteRepository>();

            services.AddScoped<ITokenService, TokenService>();


            #endregion//DIS = Dependency Injection Services


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.Use(async (ctx, next) => {
                await next();
                if (ctx.Response.StatusCode == 204)
                {
                    ctx.Response.ContentLength = 0;
                }
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            //Swager Useability
            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Andamios API"); });
            

            // CORS Useability
            app.UseCors(option => {
                option.WithOrigins(Configuration["ApplicationSettings:Origins_Url"]).AllowAnyHeader().AllowAnyMethod();
            });

            //aunthentiction
            app.UseAuthentication();

            
            app.UseMvc();
        }
    }
}
