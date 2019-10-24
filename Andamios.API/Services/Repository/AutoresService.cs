using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Andamios.API.Services.Contracts;
using Andamios.Core.Data.Entities;
using Andamios.Core.Repository.Implementations;
using Andamios.Core.Repository.Interfaces;

namespace Andamios.API.Services.Repository
{
    public class AutoresService : IAutoresService
    {
        private readonly IAutores _autoresRepository;
        public AutoresService(IAutores autoresRepository)
        {
            _autoresRepository = autoresRepository;
        }
        public async Task<List<Autor>> ListAutoresAsync()
        {
            return await _autoresRepository.ListAutoresAsync();
        }

        public async Task SaveOneAsync(Autor autor)
        {
           await _autoresRepository.SaveOneAsync(autor);
        }

        public async Task<Autor> GetOneAutor(int id)
        {
            return await _autoresRepository.GetOneAutor(id);
        }

        public Task DeleteOneAsync(Autor autor)
        {
            return _autoresRepository.DeleteOneAsync(autor);
        }

        public Task<List<Autor>> GetByCondition(Expression<Func<Autor, bool>> expression)
        {
            return _autoresRepository.GetByCondition(expression);
        }
    }
}
