using System.Collections.Generic;
using TheHunt.Host;

namespace TheHunt.Data
{
    public interface IUserRepository
    {
        IList<UserAccount> GetAllUserAccounts();

        UserAccount GetUserAccount(int id);
    }
}