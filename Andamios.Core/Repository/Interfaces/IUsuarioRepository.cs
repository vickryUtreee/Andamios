using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;

namespace Andamios.Core.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        IQueryable Usuarios { get; }
        Task<List<Usuario>> ListaUsuariosAsync();
        Task<Usuario> GetOneUsuarioAsync(string id);
        Task SaveOneUsuarioAsync(Usuario usuario);
        Task DeleteOneUsuarioAsync(Usuario usuario);
        Task ChangeStateOneUsuarioAsync(Usuario usuario);
    }
}
