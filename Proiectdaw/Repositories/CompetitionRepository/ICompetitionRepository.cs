using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.CompetitionRepository
{
    public interface ICompetitionRepository : IGenericRepository<Competition>
    {
        Task<Competition> GetByName(string name);
        Task<Competition> GetByPrizePool(int prizepool);
    }
}
