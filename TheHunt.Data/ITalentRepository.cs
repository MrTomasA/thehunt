using System.Threading.Tasks;

namespace TheHunt.Data
{
    public interface ITalentRepository
    {
        Task<DomainModel.Models.SkillSet> CreateSkillSet(DomainModel.Models.SkillSet skillSet);
    }
}