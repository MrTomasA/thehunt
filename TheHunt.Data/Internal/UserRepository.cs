using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheHunt.Host;

namespace TheHunt.Data.Internal
{
    internal class UserRepository : IUserRepository
    {
        private readonly TheHuntContext context;
        private readonly ILogger<UserRepository> logger;

        public UserRepository(TheHuntContext context, ILogger<UserRepository> logger)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
        }

        public IList<UserAccount> GetAllUserAccounts()
        {
            return context.UserAccount
                .Include(s => s.UserType)
                .Include(s => s.UserLog)
                .ToList();
        }

        public UserAccount GetUserAccount(int id)
        {
            return context.UserAccount
                .Include(s => s.UserType)
                .Include(s => s.UserLog)
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }
    }
}