using Proiectdaw.Repositories.SessionTokenRepository;
using Proiectdaw.Repositories.UserRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proiectdaw.Repositories
{
   public interface IRepositoryWrapper
    {
        IUserRepository User { get; }
        ISessionTokenRepository SessionToken { get; }

        Task SaveAsync();
    }
}
