using SooftTechnologyChallengeEj4.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SooftTechnologyChallengeEj4.Infrastructure.Data.Repositories
{
    public interface ISucursalRepository
    {
        Task<IEnumerable<Sucursal>> GetAllAsync();
        Task<Sucursal> GetOneAsync(int id);
    }
}
