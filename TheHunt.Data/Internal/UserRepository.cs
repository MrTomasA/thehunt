using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TheHunt.EntityFrameworkGenerator.Models;

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

        public async Task<DomainModel.Models.SkillSet> CreateSkillSet(DomainModel.Models.SkillSet skillSet)
        {
            if (skillSet.Id == null)
            {
                var ss = new SkillSet
                {
                    SkillSetName = skillSet.SkillSetName
                };

                context.SkillSet.Add(ss);
                await context.SaveChangesAsync();

                skillSet.Id = ss.Id;
            }

            return skillSet;
        }
    }
}