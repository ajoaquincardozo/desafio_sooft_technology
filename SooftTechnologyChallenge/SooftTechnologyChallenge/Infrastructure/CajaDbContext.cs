using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallenge.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SooftTechnologyChallenge.Infrastructure
{
    public class CajaDbContext : DbContext
    {
        public virtual DbSet<Caja> Cajas { get; set; }

        public CajaDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Caja>().HasKey(p => p.Id);
            modelBuilder.Entity<Caja>().Property(p => p.SucursalId);
            modelBuilder.Entity<Caja>().Property(p => p.Descripcion);
            modelBuilder.Entity<Caja>().Property(p => p.TipoCajaId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
