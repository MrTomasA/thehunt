using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TheHunt.EntityFrameworkGenerator.Models;

namespace TheHunt.Data.Internal
{
    internal class TalentRepository : ITalentRepository
    {
        private readonly TheHuntContext context;
        private readonly ILogger<UserRepository> logger;

        public TalentRepository(TheHuntContext context, ILogger<UserRepository> logger)
        {
            this.context = context ?? throw new System.ArgumentNullException(nameof(context));
            this.logger = logger ?? throw new System.ArgumentNullException(nameof(logger));
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