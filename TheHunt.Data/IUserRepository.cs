using System.Collections.Generic;
using System.Threading.Tasks;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data
{
    public interface IUserRepository
    {
        IEnumerable<DomainModel.Models.UserAccount> GetUserAccounts();

        IList<DomainModel.Models.UserType> GetUserTypes();

        UserAccount GetUserAccount(int id);

        Task<DomainModel.Models.UserType> CreateUserType(DomainModel.Models.UserType userType);

        Task<DomainModel.Models.UserLog> CreateUserLog(DomainModel.Models.UserLog userLog);

        Task<DomainModel.Models.UserAccount> CreateUserAccount(DomainModel.Models.UserAccount userAccount);
    }
}