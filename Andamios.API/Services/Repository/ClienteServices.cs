using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.API.Services.Contracts;
using Andamios.Core.Data.Entities;
using Andamios.Core.Repository.Interfaces;

namespace Andamios.API.Services.Repository
{
    public class ClienteServices : IClienteServices
    {
        private readonly IClienteRepository _clienteServices;
        public ClienteServices(IClienteRepository clienteRepository)
        {
            _clienteServices = clienteRepository;
        }

        public Task<IEnumerable<Ddcliente>> ListClientesAsync()
        {
            return _clienteServices.ListClientesAsync();
        }

        public Task<IEnumerable<Ddcliente>> GetClientesByCondition()
        {
            return _clienteServices.GetClientesByCondition();
        }

        public Task<Ddcliente> GetOneClientAsync(int id)
        {
            return _clienteServices.GetOneClientAsync(id);
        }

        public Task SaveOneAsync(Ddcliente cliente)
        {
            return _clienteServices.SaveOneAsync(cliente);
        }

        public Task DeleteOneAsync(Ddcliente cliente)
        {
            return _clienteServices.DeleteOneAsync(cliente);
        }

        public void Dispose()
        {
            _clienteServices.Dispose();
        }
    }
}
