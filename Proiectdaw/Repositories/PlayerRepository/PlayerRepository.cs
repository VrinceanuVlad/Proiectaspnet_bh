using Microsoft.EntityFrameworkCore;
using Proiectdaw.Data;
using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.PlayerRepository
{
    public class PlayerRepository : GenericRepository<Player>, IPlayerRepository
    {
        public PlayerRepository(Context context) : base(context) { }
        public async Task<List<Player>> GetAllPlayersWithTeams()
        {
            return await _context.Players.Include(p => p.Team).ToListAsync();
        }

        public async Task<Player> GetByAge(int age)
        {
            return await _context.Players.Where(p => p.Name.Equals(age)).FirstOrDefaultAsync();
        }

        public async Task<Player> GetByName(string name)
        {
            return await _context.Players.Where(p => p.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
