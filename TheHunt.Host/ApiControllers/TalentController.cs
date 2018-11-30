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
        private readonly IUserRepository userRepository;

        public TalentController(IUserRepository userRepository) => this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        [HttpPost]
        [Route("skill-set")]
        [SwaggerOperation(nameof(SaveSkillSet))]
        [ProducesResponseType(typeof(BusinessStream), 201)]
        public async Task<ActionResult<SkillSet>> SaveSkillSet([FromBody]SkillSet skillSet) => await userRepository.CreateSkillSet(skillSet);
    }
}