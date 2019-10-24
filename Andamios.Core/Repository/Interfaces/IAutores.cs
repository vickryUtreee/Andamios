using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;

namespace Andamios.Core.Repository.Interfaces
{
    public interface IAutores
    {
        Task<Autor> GetOneAutor(int id);
        Task<List<Autor>> ListAutoresAsync();
        Task<List<Autor>> GetByCondition(Expression<Func<Autor, bool>> expression);
        Task SaveOneAsync(Autor autor);
        Task DeleteOneAsync(Autor autor);
    }
}
