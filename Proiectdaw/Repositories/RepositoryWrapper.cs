using Proiectdaw.Data;
using Proiectdaw.Repositories.SessionTokenRepository;
using Proiectdaw.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories
{
    
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private readonly Context _context;
        private IUserRepository _user;
        private ISessionTokenRepository _sessionToken;

    public RepositoryWrapper(Context context)
        {
            _context = context;
        }

        public IUserRepository User
        {
            get
            {
                if (_user == null) _user = new UserRepository.UserRepository(_context);
                return _user;
            }
        }

        private IUserRepository UserRepository(Context context)
        {
            throw new NotImplementedException();
        }

        public ISessionTokenRepository SessionToken
        {
            get
            {
                if (_sessionToken == null) _sessionToken = new SessionTokenRepository.SessionTokenRepository(_context);
                return _sessionToken;
            }
        }

        private ISessionTokenRepository SessionTokenRepository(Context context)
        {
            throw new NotImplementedException();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
