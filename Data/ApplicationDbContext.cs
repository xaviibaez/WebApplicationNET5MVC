using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationNET.Models;

namespace WebApplicationNET.Data
{
    public class ApplicationDbContext : DbContext
    {
        //Conexion a la bbdd
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Setter y Getters que usamos para recuperar datos de la bbdd
        public DbSet<Category> Category { get; set; }
        public DbSet<ApplicationType> ApplicationType { get; set; }
    }
}
