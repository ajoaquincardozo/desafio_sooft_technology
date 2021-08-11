using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SooftTechnologyChallenge.Infrastructure
{
    public class CajaRepository : DbContext
    {
        private readonly CajaDbContext _db;
        private readonly ICache _cache;
        private readonly string CACHE_KEY = "cajas";
        private readonly int CACHE_DURATION = 300; //5hs

        public CajaRepository(CajaDbContext db, ICache cache)
        {
            _db = db ?? throw new ArgumentNullException(nameof(CajaDbContext));
            _cache = cache;
        }

        public async Task AddAsync(Entities.Caja caja)
        {
            await _db.Cajas.AddAsync(caja);
            await _db.SaveChangesAsync();

            var cacheModel = (await _cache.GetOrDefaultAsync<CacheModel>(CACHE_KEY)) ?? new CacheModel();
            var sucursalID = caja.SucursalId;

            var cajasPorSucursal = cacheModel.CajasPorSucursal.ContainsKey(sucursalID) ? cacheModel.CajasPorSucursal[sucursalID] : new List<Entities.Caja>();
            cajasPorSucursal.Add(caja);

            cacheModel.Cajas[caja.Id] = caja;
            cacheModel.CajasPorSucursal[sucursalID] = cajasPorSucursal;
            await _cache.AddAsync(CACHE_KEY, cacheModel, CACHE_DURATION);
        }

        public async Task<IEnumerable<Entities.Caja>> GetAllAsync()
        {
            var cacheModel = await _cache.GetOrDefaultAsync<CacheModel>(CACHE_KEY) ?? new CacheModel();
            return cacheModel.Cajas.Count > 0  ? cacheModel.Cajas.Values.ToList()  : await _db.Cajas.ToListAsync();
        }

        public async Task<IEnumerable<Entities.Caja>> GetAllBySucursalAsync(int sucursalId)
        {
            var cacheModel = await _cache.GetOrDefaultAsync<CacheModel>(CACHE_KEY) ?? new CacheModel();
            var hasCache  = cacheModel.CajasPorSucursal.ContainsKey(sucursalId);

            return hasCache
                ? cacheModel.CajasPorSucursal[sucursalId].ToList()
                : await _db.Cajas.Where(x => x.SucursalId == sucursalId).ToListAsync();
        }

        public async Task<Entities.Caja> GetOneAsync(Guid id)
        {
            var cacheModel = await _cache.GetOrDefaultAsync<CacheModel>(CACHE_KEY) ?? new CacheModel();
            var hasCache = cacheModel.Cajas.ContainsKey(id);

            return hasCache 
                ? cacheModel.Cajas[id]
                : await _db.Cajas.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}
