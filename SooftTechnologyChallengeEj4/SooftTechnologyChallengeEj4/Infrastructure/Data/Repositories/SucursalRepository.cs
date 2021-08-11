using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallengeEj4.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SooftTechnologyChallengeEj4.Infrastructure.Data.Repositories
{
    public class SucursalRepository : BaseRepository<Sucursal, int>, ISucursalRepository
    {

        public SucursalRepository(BaseDbContext<Sucursal, int> db) : base(db) { }
    }
}
