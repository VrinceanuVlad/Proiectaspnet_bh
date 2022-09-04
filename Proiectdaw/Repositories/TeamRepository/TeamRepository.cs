using Microsoft.EntityFrameworkCore;
using Proiectdaw.Data;
using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.TeamRepository
{
    public class TeamRepository : GenericRepository<Team>, ITeamRepository
    {
        public TeamRepository(Context context) : base(context) { }

    

        public async Task<List<Team>> GetAllTeamsWithCoches()
        {
            return await _context.Teams.Include(t => t.Coach).ToListAsync();
        }

        public async Task<Team> GetByName(string name)
        {
            return await _context.Teams.Where(t => t.Name.Equals(name)).FirstOrDefaultAsync();
            
        }

        public async Task<Team> GetByIdWithCouches(int id)
        {
            return await _context.Teams.Include(t => t.Coach).Where(t => t.Id == id).FirstOrDefaultAsync();
        }
    }
}
