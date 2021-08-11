using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallengeEj4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SooftTechnologyChallengeEj4.Infrastructure.Data.Repositories
{
    public class CajaRepository : BaseRepository<Caja, Guid>, ICajaRepository, IDisposable
    {
        public CajaRepository(CajaDbContext db) : base(db) { }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
