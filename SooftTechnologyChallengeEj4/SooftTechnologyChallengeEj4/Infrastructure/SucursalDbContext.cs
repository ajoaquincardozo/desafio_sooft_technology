using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallengeEj4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SooftTechnologyChallengeEj4.Infrastructure
{
    public class SucursalDbContext : BaseDbContext<Sucursal, int>
    {
        public SucursalDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
