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
    public class ClienteRepository : IClienteRepository
    {
        private readonly AndamiosDominicanosContext _context;

        public ClienteRepository(AndamiosDominicanosContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ddcliente>> ListClientesAsync()
        {
            return await _context.Ddcliente.ToListAsync();
        }

        public Task<IEnumerable<Ddcliente>> GetClientesByCondition()
        {
            throw new NotImplementedException();
        }

        public async Task<Ddcliente> GetOneClientAsync(int id)
        {
            return await _context.Ddcliente.FindAsync(id);
        }

        public async Task SaveOneAsync(Ddcliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                _context.Ddcliente.Add(cliente);
            }
            else
            {
                var c = _context.Ddcliente.FirstOrDefaultAsync(x => x.ClienteId == cliente.ClienteId);
                
                _context.Entry(c).CurrentValues.SetValues(cliente);
                _context.Entry(c).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();
        }

        public Task DeleteOneAsync(Ddcliente cliente)
        {
            cliente.ClienteIsActive = !cliente.ClienteIsActive;

            return this.SaveOneAsync(cliente);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
