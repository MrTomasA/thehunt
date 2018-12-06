using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TheHunt.Data;
using TheHunt.DomainModel.Models;

namespace TheHunt.Host.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TalentController : ControllerBase
    {
        private readonly ITalentRepository talentRepository;

        public TalentController(ITalentRepository talentRepository) => this.talentRepository = talentRepository ?? throw new ArgumentNullException(nameof(talentRepository));

        [HttpPost]
        [Route("skill-set")]
        [SwaggerOperation(nameof(CreateSkillSet))]
        [ProducesResponseType(typeof(BusinessStream), 201)]
        public async Task<SkillSet> CreateSkillSet([FromBody]SkillSet skillSet) => await talentRepository.CreateSkillSet(skillSet);
    }
}