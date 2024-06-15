using AdmTarea.DA.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdmTarea.DA.Contexto
{
    public class FotoContext : DbContext
    {
        public FotoContext(DbContextOptions options)
             : base(options)
        {
        }
        public DbSet<FotoDA> FotoDA { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FotoDA>().ToTable("Foto");
        }
    }
}
