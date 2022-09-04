using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.CoachRepository
{
    public interface ICoachRepository : IGenericRepository<Coach>

    {
        Task<List<Coach>> GetAllCoachesWithTeams();
        Task<Coach> GetByName(string name);
        Task<Coach> GetByIdWithTeams(int id);
    }
}

