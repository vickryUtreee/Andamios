using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.API.Services.Contracts;
using Andamios.Core.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Andamios.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteServices _clienteService;

        public ClienteController(IClienteServices clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: api/Cliente
        [HttpGet]
        public async Task<List<Ddcliente>> Get()
        {
            IEnumerable<Ddcliente> clientes = await _clienteService.ListClientesAsync();

            return clientes.ToList();

        }

        // GET: api/Cliente/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cliente
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
