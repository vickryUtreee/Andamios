using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;

namespace Andamios.API.Services.Contracts
{
    public interface IUsuarioService
    {
        IQueryable Usuarios { get; }
        Task<List<Usuario>> ListaUsuariosAsync();
        Task<Usuario> GetOneUsuarioAsync(string id);
        Task SaveOneUsuarioAsync(Usuario usuario);
        Task DeleteOneUsuarioAsync(Usuario usuario);
        Task ChangeStateOneUsuarioAsync(Usuario usuario);
    }
}
