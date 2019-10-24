using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;

namespace Andamios.API.Services.Contracts
{
    public interface IClienteServices
    {
        Task<IEnumerable<Ddcliente>> ListClientesAsync();
        Task<IEnumerable<Ddcliente>> GetClientesByCondition();
        Task<Ddcliente> GetOneClientAsync(int id);
        Task SaveOneAsync(Ddcliente cliente);
        Task DeleteOneAsync(Ddcliente cliente);
        void Dispose();
    }
}
