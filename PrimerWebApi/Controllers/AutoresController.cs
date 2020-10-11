using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiExamplePractice.Helpers.Filter;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PrimerWebApi.Context;
using PrimerWebApi.Entities;
using PrimerWebApi.Services;

namespace PrimerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IClaseB claseB;
        private readonly ILogger<AutoresController> logger;

        public AutoresController(ApplicationDbContext context, ClaseB claseB, 
            ILogger<AutoresController> logger)
        {
            this.context = context;
            this.claseB = claseB;
            this.logger = logger;
        }

        [HttpGet]
        [ServiceFilter(typeof(FilterAction))]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            claseB.HacerAlgo();
            logger.LogInformation("Logger info en autores");
            return context.Autores.Include(x => x.Libros).ToList();
        }

        [HttpGet("/listado")]
        [HttpGet("listado")]
        public ActionResult<IEnumerable<Autor>> GetListado()
        {    
            return context.Autores.Include(x => x.Libros).ToList();
        }


        [HttpGet("{id}/{param2=nada}", Name = "ObtrenerAutor")]
        public async Task<ActionResult<Autor>> Get(int id, string param2)
        {
            var autor = await context.Autores.Include(x => x.Libros).FirstOrDefaultAsync(x => x.Id == id);

            if (autor == null)
            {
                logger.LogWarning($"El autor del ID {id} no a sido encontrado");
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtrenerAutor", new { id = autor.Id }, autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor autor)
        {
            if (id != autor.Id)
                return BadRequest();


            context.Entry(autor).State = EntityState.Modified;
            context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autores.FirstOrDefault(x => x.Id == id);

            if (autor == null)
                return NotFound();

            context.Autores.Remove(autor);
            context.SaveChanges();

            return autor;
        }
    }
}
