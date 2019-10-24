using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;
using Andamios.Core.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Andamios.Core.Repository.Implementations
{
    public class AutoresRepository : IAutores
    {
        private readonly AndamiosDominicanosContext _context;

        public AutoresRepository(AndamiosDominicanosContext context)
        {
            _context = context;
        }

        public async Task<Autor> GetOneAutor(int id)
        {
            return await _context.FindAsync<Autor>(id);
        }

        public async Task<List<Autor>> ListAutoresAsync()
        {
            return await _context.Autores.ToListAsync(); 
        }

        public Task<List<Autor>> GetByCondition(Expression<Func<Autor, bool>> expression)
        {
            return _context.Autores.Where(expression).ToListAsync();
        }

        public async Task SaveOneAsync(Autor autor)
        {
            if (autor.Id == 0)
            {
               _context.Add(autor);
            }
            else
            {
                _context.Entry(autor).State = EntityState.Modified;
            }

            await _context.SaveChangesAsync();

        }


        public async Task DeleteOneAsync(Autor autor)
        {

            _context.Autores.Remove(autor);

           await _context.SaveChangesAsync();
        }
    }
}
