using Microsoft.EntityFrameworkCore;
using Proiectdaw.Data;
using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.CompetitionRepository
{
    public class CompetitionRepository : GenericRepository<Competition>, ICompetitionRepository
    {
        public CompetitionRepository(Context context) : base(context) { }
        public async Task<Competition> GetByName(string name)
        {
            return await _context.Competitions.Where(c => c.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<Competition> GetByPrizePool(int prizepool)
        {
            return await _context.Competitions.Where(c => c.Prizepool.Equals(prizepool)).FirstOrDefaultAsync();
        }
    }
}
