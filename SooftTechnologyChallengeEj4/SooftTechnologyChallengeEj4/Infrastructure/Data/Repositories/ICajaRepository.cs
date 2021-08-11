using SooftTechnologyChallengeEj4.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SooftTechnologyChallengeEj4.Infrastructure.Data.Repositories
{
    public interface ICajaRepository
    {
        Task<IEnumerable<Caja>> GetAllAsync();
        Task<Caja> GetOneAsync(Guid id);
    }
}
