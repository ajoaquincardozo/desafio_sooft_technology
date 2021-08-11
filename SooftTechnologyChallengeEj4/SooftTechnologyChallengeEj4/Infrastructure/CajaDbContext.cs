using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallengeEj4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SooftTechnologyChallengeEj4.Infrastructure
{
    public class CajaDbContext : BaseDbContext<Caja, Guid>
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
