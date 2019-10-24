using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.API.Services.Contracts;
using Andamios.Core.Data.Entities;
using Andamios.Core.Repository.Interfaces;

namespace Andamios.API.Services.Repository
{

    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioServices;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioServices = usuarioRepository;
        }

        public IQueryable Usuarios => _usuarioServices.Usuarios;
        

        public Task<List<Usuario>> ListaUsuariosAsync()
        {
            return _usuarioServices.ListaUsuariosAsync();
        }

        public Task<Usuario> GetOneUsuarioAsync(string id)
        {
            return _usuarioServices.GetOneUsuarioAsync(id);
        }

        public Task SaveOneUsuarioAsync(Usuario usuario)
        {
            return _usuarioServices.SaveOneUsuarioAsync(usuario);
        }

        public Task DeleteOneUsuarioAsync(Usuario usuario)
        {
            return _usuarioServices.DeleteOneUsuarioAsync(usuario);
        }

        public Task ChangeStateOneUsuarioAsync(Usuario usuario)
        {
            return _usuarioServices.ChangeStateOneUsuarioAsync(usuario);
        }
    }
}
