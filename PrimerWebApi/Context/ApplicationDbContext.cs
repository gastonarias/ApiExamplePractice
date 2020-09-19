using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PrimerWebApi.Entities;
using PrimerWebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PrimerWebApi.Context
{
    public class ApplicationDbContext : DbContext
    {
        //static LoggerFactory object
        public static readonly ILoggerFactory loggerFactory = new LoggerFactory(new[] {
              new LoggerProvider()
        });


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Autor> Autores { get; set; }
        public DbSet<Libro> Libros { get; set; }

    }
}
