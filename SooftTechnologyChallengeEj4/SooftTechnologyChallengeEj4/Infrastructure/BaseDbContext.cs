using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallengeEj4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SooftTechnologyChallengeEj4.Infrastructure
{
    public class BaseDbContext<Entity, TypeId> : DbContext
        where Entity : BaseEntity<TypeId>
    {
        public virtual DbSet<Entity> Entities { get; set; }

        public BaseDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
