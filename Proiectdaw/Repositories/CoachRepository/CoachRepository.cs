using Microsoft.EntityFrameworkCore;
using Proiectdaw.Data;
using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.CoachRepository
{
    public class CoachRepository : GenericRepository<Coach>, ICoachRepository
    {

        public CoachRepository(Context context) : base(context) { }
        public async Task<List<Coach>> GetAllCoachesWithTeams()
        {
            return await _context.Coaches.Include(c => c.Team).ToListAsync();
        }

        public async Task<Coach> GetByIdWithTeams(int id)
        {
            return await _context.Coaches.Include(c => c.Team).Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Coach> GetByName(string name)
        {
            return await _context.Coaches.Where(c => c.Name.Equals(name)).FirstOrDefaultAsync();
        }
    }
}
