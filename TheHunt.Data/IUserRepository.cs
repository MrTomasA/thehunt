using System.Collections.Generic;
using System.Threading.Tasks;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data
{
    public interface IUserRepository
    {
        IList<UserAccount> GetAllUserAccounts();

        UserAccount GetUserAccount(int id);

        Task<DomainModel.Models.SkillSet> CreateSkillSet(DomainModel.Models.SkillSet skillSet);
    }
}