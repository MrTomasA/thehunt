using System.Collections.Generic;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data
{
    public interface IUserRepository
    {
        IList<UserAccount> GetAllUserAccounts();

        UserAccount GetUserAccount(int id);
    }
}