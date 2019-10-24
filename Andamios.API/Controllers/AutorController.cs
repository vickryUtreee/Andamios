using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Andamios.API.Models;
using Andamios.API.Services.Contracts;
using Andamios.API.Services.Repository;
using Andamios.Core.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Andamios.API.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutoresService _autoresService;
        public AutorController(IAutoresService autoresService)
        {
            _autoresService = autoresService;
        }

        [HttpGet]
        [Route("ListaAutores")]
        //GET : /api/Autor/ListaAutores/
        public async Task<ActionResult<Autor>> Get()
        
        {
            var autores = await _autoresService.ListAutoresAsync();

            if (!autores.Any())
            {
                return NotFound();
            }

            return Ok(autores);
        }

        [HttpGet("{id}", Name = "VerAutor")]
        //GET : /api/autor/VerAutor/{id}
        public async Task<ActionResult<Autor>> Get(int id)
        {
            var autor = await _autoresService.GetOneAutor(id);

            if (autor == null)
            {
                return NotFound(id);
            }

            return autor;
        }

        //[HttpGet("{id}")]
        //[Route("ListaFiltrada/{condicion}")]
        ////GET : /api/autor/VerAutor/{id}
        //public Task<ActionResult<List<Autor>>> Get(string condicion)
        //{
        //    Task<List<Autor>> autor = _autoresService.GetByCondition(c => c.Nombre == condicion);

        //    if (!autor)
        //    {
        //        return NotFound(condicion);
        //    }

        //    return autor;
        //}

        [HttpPost]
        [Route("GuardarAutor")]
        // POST : /api/Autor/GuardarAutor/
        public async Task<ActionResult<Autor>> Post(AutorViewModel model)
        {
            var autor = new Autor()
            {
                Nombre = model.Name
            };
            try
            {
                await _autoresService.SaveOneAsync(autor);

                // return Ok(new { Nombre = autor.Nombre, Id = autor.Id });
                return new CreatedAtRouteResult("VerAutor", 
                    new { id = autor.Id}, autor);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }

        [HttpDelete("{id}")]
        // DELETE : /api/Autor/{id}
        public async Task<ActionResult<Autor>> Delete(int id)
        {
            var autor = await _autoresService.GetOneAutor(id);

            if (autor == null)
            {
                return NotFound(id);
            }

            await _autoresService.DeleteOneAsync(autor);

            return autor;
        }
    }
}