using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.TeamRepository
{
    public interface ITeamRepository :IGenericRepository<Team>

    {
        Task<List<Team>> GetAllTeamsWithCoches();
        Task<Team> GetByName(string name);
        Task<Team> GetByIdWithCouches(int id);
    }
}
