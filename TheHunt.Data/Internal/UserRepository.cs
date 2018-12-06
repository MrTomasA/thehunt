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

        public IEnumerable<DomainModel.Models.UserAccount> GetUserAccounts()
        {
            var results = new List<DomainModel.Models.UserAccount>();

            var userAccountEf = context.UserAccount.ToList();

            foreach (var item in userAccountEf)
            {
                results.Add(new DomainModel.Models.UserAccount
                {
                    Id = item.Id,
                    Email = item.Email,
                    EmailNotificationActive = item.EmailNotificationActive,
                    ContactNumber = item.ContactNumber,
                    DateOfBirth = item.DateOfBirth,
                    Gender = item.Gender,
                    IsActive = item.IsActive,
                    RegistrationDate = item.RegistrationDate,
                    UserTypeId = item.UserTypeId
                });
            }

            return results;
        }

        public UserAccount GetUserAccount(int id)
        {
            return context.UserAccount
                .Include(s => s.UserType)
                .Include(s => s.UserLog)
                .Where(m => m.Id == id)
                .FirstOrDefault();
        }

        public IList<DomainModel.Models.UserType> GetUserTypes()
        {
            var results = new List<DomainModel.Models.UserType>();

            var userTypeEf = context.UserType.ToList();

            foreach (var item in userTypeEf)
            {
                results.Add(new DomainModel.Models.UserType { Id = item.Id, UserTypeName = item.UserTypeName });
            }

            return results;
        }

        public async Task<DomainModel.Models.UserType> CreateUserType(DomainModel.Models.UserType userType)
        {
            if (userType.Id == null)
            {
                var ut = new UserType
                {
                    UserTypeName = userType.UserTypeName
                };

                context.UserType.Add(ut);
                await context.SaveChangesAsync();

                userType.Id = ut.Id;
            }

            return userType;
        }

        public async Task<DomainModel.Models.UserLog> CreateUserLog(DomainModel.Models.UserLog userLog)
        {
            if (userLog.UserAccountId > 0)
            {
                var ul = new UserLog
                {
                    UserAccountId = userLog.UserAccountId,
                    LastLoginDate = userLog.LastLoginDate,
                    LastJobApplyDate = userLog.LastJobApplyDate
                };

                context.UserLog.Add(ul);
                await context.SaveChangesAsync();
            }

            return userLog;
        }

        public async Task<DomainModel.Models.UserAccount> CreateUserAccount(DomainModel.Models.UserAccount userAccount)
        {
            if (userAccount.Id == null)
            {
                var ua = new UserAccount
                {
                    IsActive = userAccount.IsActive,
                    Gender = userAccount.Gender,
                    RegistrationDate = userAccount.RegistrationDate,
                    DateOfBirth = userAccount.DateOfBirth,
                    ContactNumber = userAccount.ContactNumber,
                    Email = userAccount.Email,
                    UserTypeId = userAccount.UserTypeId,
                    EmailNotificationActive = userAccount.EmailNotificationActive
                };

                context.UserAccount.Add(ua);
                await context.SaveChangesAsync();

                userAccount.Id = ua.Id;
            }

            return userAccount;
        }
    }
}