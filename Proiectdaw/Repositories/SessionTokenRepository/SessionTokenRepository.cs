using Microsoft.EntityFrameworkCore;
using Proiectdaw.Data;
using Proiectdaw.Entities;
using Proiectdaw.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories.SessionTokenRepository
{
    public class SessionTokenRepository: GenericRepository<SessionToken>,ISessionTokenRepository
    {
        public SessionTokenRepository(Context context) : base(context) { }

        public async Task<SessionToken> GetByJTI(string jti)
        {
            return await _context.SessionTokens.FirstOrDefaultAsync(t => t.Jti.Equals(jti));
        }
    }
}

