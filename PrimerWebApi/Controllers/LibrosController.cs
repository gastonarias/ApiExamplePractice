﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrimerWebApi.Context;
using PrimerWebApi.Entities;

namespace PrimerWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibrosController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        public LibrosController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Libro>> Get()
        {
            return context.Libros.Include(x => x.Autor).ToList();
        }

        [HttpGet("{id}", Name = "ObtrenerLibro")]
        public ActionResult<Libro> Get(int id)
        {
            var libro = context.Libros.FirstOrDefault(x => x.Id == id);

            if (libro == null)
                return NotFound();

            return libro;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Libro libro)
        {
            context.Add(libro);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtrenerLibro", new { id = libro.Id }, libro);
        }
    }
}
