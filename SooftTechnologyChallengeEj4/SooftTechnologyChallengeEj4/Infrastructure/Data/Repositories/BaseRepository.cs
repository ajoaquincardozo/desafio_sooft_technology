using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallengeEj4.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SooftTechnologyChallengeEj4.Infrastructure.Data.Repositories
{
    public abstract class BaseRepository<Entity, TypeId>
        where Entity : BaseEntity<TypeId>
    {
        protected BaseDbContext<Entity, TypeId> _db { get; private set; }

        public BaseRepository(BaseDbContext<Entity, TypeId> db) => _db = db;

        public async Task<IEnumerable<Entity>> GetAllAsync()
            => await _db.Entities.ToListAsync();

        public async Task<Entity> GetOneAsync(TypeId id)
            => await _db.Entities.FirstOrDefaultAsync(x => x.Id.Equals(id));
    }
}
