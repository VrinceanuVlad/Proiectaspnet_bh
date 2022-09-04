using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.PlayerRepository
{
    public interface IPlayerRepository : IGenericRepository<Player>
    {
        Task<List<Player>> GetAllPlayersWithTeams();
        Task<Player> GetByName(string name);
        Task<Player> GetByAge(int age);
    }
}
