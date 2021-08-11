using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallenge.Entities;
using SooftTechnologyChallenge.Infrastructure;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections;

namespace SooftTechnologyChallenge
{
    public class Program
    {
        #region -- Implementation example -- 

        public class CacheItemImpl
        {
            public object Model { get; set; }
            public int? DurationInMinutes { get; set; }
            public DateTime FechaCreacion { get; set; }
        }

        public class CacheImpl : ICache
        {
            private readonly Dictionary<string, CacheItemImpl> storage;

            public CacheImpl()
            {
                storage = new Dictionary<string, CacheItemImpl>();
            }

            public Task AddAsync<T>(string key, T obj, int? durationInMinutes)
            {
                storage[key] = new CacheItemImpl()
                {
                    Model = obj,
                    DurationInMinutes = durationInMinutes,
                    FechaCreacion = DateTime.Now
                };

                return Task.CompletedTask;
            }

            public Task<T> GetOrDefaultAsync<T>(string key)
            {
                var cacheItem = storage.ContainsKey(key) ? storage[key] : null;
                bool isValid = cacheItem != null && (DateTime.Now - cacheItem.FechaCreacion).TotalMinutes < cacheItem.DurationInMinutes;
                return Task.FromResult(isValid ? (T)cacheItem.Model : default(T));
            }

            public Task RemoveAsync(string key)
            {
                storage.Remove(key);
                return Task.CompletedTask;
            }
        }

        #endregion

        private static DbContextOptions<CajaDbContext> GetCajaOptions()
        {
            return new DbContextOptionsBuilder<CajaDbContext>()
                            .UseInMemoryDatabase(databaseName: "Test")
                            .Options;
        }

        private static Task<CajaRepository> GetRepositoryWithData(DbContextOptions<CajaDbContext> options)
        {
            using (var repository = new CajaRepository(new CajaDbContext(options), new CacheImpl()))
            {
                var cajas = new List<Caja>()
                {
                    new Caja(Guid.NewGuid(), 1, "Soy un reee caja", 1),
                    new Caja(Guid.NewGuid(), 1, "cajin", 2),
                    new Caja(Guid.NewGuid(), 2, "cajota", 3),
                    new Caja(Guid.NewGuid(), 3, "cajita", 4)
                };

                cajas.ForEach(async caja => await repository.AddAsync(caja));
                return Task.FromResult(repository);
            }
        }

        public async static void CajaEjemplo()
        {
            var repository = await GetRepositoryWithData(GetCajaOptions());

            Console.WriteLine("-- Obtener todas las cajas --");
            var cajas = (await repository.GetAllAsync()).ToList();
            cajas.ForEach(Console.WriteLine);

            Console.WriteLine("-- Obtener todas las cajas por sucursal --");
            var cajasPorSucursal = (await repository.GetAllBySucursalAsync(cajas.First().SucursalId)).ToList();
            cajasPorSucursal.ForEach(Console.WriteLine);

            Console.WriteLine("-- Obtener solo una caja  --");
            var cajaUnica = await repository.GetOneAsync(cajas.Last().Id);
            Console.WriteLine(cajaUnica); 
        }

        static void Main(string[] args)
        {
            CajaEjemplo();
        }
    }
}
