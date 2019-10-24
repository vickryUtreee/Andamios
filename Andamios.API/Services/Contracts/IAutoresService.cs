using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;

namespace Andamios.API.Services.Contracts
{
    public interface IAutoresService
    {
        Task<List<Autor>> ListAutoresAsync();
        Task SaveOneAsync(Autor autor);
        Task<Autor> GetOneAutor(int id);
        Task DeleteOneAsync(Autor autor);
        Task<List<Autor>> GetByCondition(Expression<Func<Autor, bool>> expression);

    }
}
