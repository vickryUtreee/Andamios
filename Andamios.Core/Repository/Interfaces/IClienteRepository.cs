using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Andamios.Core.Data.Entities;

namespace Andamios.Core.Repository.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Ddcliente>> ListClientesAsync();
        Task<IEnumerable<Ddcliente>> GetClientesByCondition();
        Task<Ddcliente> GetOneClientAsync(int id);
        Task SaveOneAsync(Ddcliente cliente);
        Task DeleteOneAsync(Ddcliente cliente);
        void Dispose();
    }
}
