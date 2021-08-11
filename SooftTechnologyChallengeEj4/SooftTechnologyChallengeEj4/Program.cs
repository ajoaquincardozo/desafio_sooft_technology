using Microsoft.EntityFrameworkCore;
using SooftTechnologyChallengeEj4.Domain.Entities;
using SooftTechnologyChallengeEj4.Infrastructure;
using SooftTechnologyChallengeEj4.Infrastructure.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SooftTechnologyChallengeEj4
{
    public class Program
    {
        #region Caja

        private static DbContextOptions<CajaDbContext> GetCajaOptions()
        {
            return new DbContextOptionsBuilder<CajaDbContext>()
                            .UseInMemoryDatabase(databaseName: "Test")
                            .Options;
        }

        private static void InitializeDbCajas(DbContextOptions<CajaDbContext> options)
        {
            using (var context = new CajaDbContext(options))
            using (var repository = new CajaRepository(context))
            {
                var cajas = new List<Caja>()
                {
                    new Caja(Guid.NewGuid(), 1, "Soy un reee caja", 1),
                    new Caja(Guid.NewGuid(), 1, "cajin", 2),
                    new Caja(Guid.NewGuid(), 1, "cajota", 3),
                    new Caja(Guid.NewGuid(), 1, "cajita", 4)
                };

                context.Entities.AddRange(cajas);
                context.SaveChanges();
            }
        }

        public async static void CajaEjemplo()
        {
            var options = GetCajaOptions();
            InitializeDbCajas(options);

            using (var repository = new CajaRepository(new CajaDbContext(options)))
            {
                IEnumerable<Caja> cajas = await repository.GetAllAsync();

                Console.WriteLine("GetAllAsync");
                foreach (var caja in cajas)
                {
                    Console.WriteLine(caja.ToString());
                }

                Console.WriteLine("GetOneAsync");
                foreach (var caja in cajas)
                {
                    Caja cajaDB = await repository.GetOneAsync(caja.Id);
                    Console.WriteLine(cajaDB.ToString());
                }
            }
        }

        #endregion

        public static void Main(string[] args)
        {
            CajaEjemplo();
        }
    }
}
