using System.Collections.Generic;
using System.Threading.Tasks;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data
{
    public interface IUserRepository
    {
        IList<UserAccount> GetAllUserAccounts();

        IList<DomainModel.Models.UserType> GetUserTypes();

        UserAccount GetUserAccount(int id);

        Task<DomainModel.Models.UserType> CreateUserType(DomainModel.Models.UserType userType);

        Task<DomainModel.Models.UserLog> CreateUserLog(DomainModel.Models.UserLog userLog);

        Task<DomainModel.Models.UserAccount> CreateUserAccount(DomainModel.Models.UserAccount userAccount);
    }
}