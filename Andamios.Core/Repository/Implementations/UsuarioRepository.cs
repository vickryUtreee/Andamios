using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;
using Andamios.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Andamios.Core.Repository.Implementations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AndamiosDominicanosContext _context;

        public UsuarioRepository(AndamiosDominicanosContext context)
        {
            _context = context;
        }

        public IQueryable Usuarios => _context.Usuarios.AsQueryable();

        public Task<List<Usuario>> ListaUsuariosAsync()
        {
            return _context.Usuarios.ToListAsync();
        }

        public Task<Usuario> GetOneUsuarioAsync(string id)
        {
            return _context.Usuarios.FindAsync(id);
        }

        public async Task SaveOneUsuarioAsync(Usuario usuario)
        {
            if (string.IsNullOrEmpty(usuario.Id))
            {
                _context.Usuarios.Add(usuario);
            }
            else
            {
                var u = await _context.Usuarios.FirstOrDefaultAsync(x => x.Id == usuario.Id);

                _context.Entry(u).CurrentValues.SetValues(usuario);
                _context.Entry(u).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteOneUsuarioAsync(Usuario usuario)
        {
            _context.Usuarios.Remove(usuario);

            await _context.SaveChangesAsync();
        }

        public async Task ChangeStateOneUsuarioAsync(Usuario usuario)
        {
            usuario.Estado = !usuario.Estado;

            _context.Add(usuario);

            await _context.SaveChangesAsync();
        }
    }
}
