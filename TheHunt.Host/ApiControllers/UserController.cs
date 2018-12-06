using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NSwag.Annotations;
using TheHunt.Data;
using TheHunt.DomainModel.Models;

namespace TheHunt.Host.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UserController(IUserRepository userRepository) => this.userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));

        [HttpGet]
        [Route("user-type")]
        [SwaggerOperation(nameof(GetUserTypes))]
        [ProducesResponseType(typeof(IEnumerable<UserType>), 200)]
        public IEnumerable<UserType> GetUserTypes() => userRepository.GetUserTypes();

        [HttpPost]
        [Route("user-type")]
        [SwaggerOperation(nameof(CreateUserType))]
        [ProducesResponseType(typeof(UserType), 201)]
        public async Task<UserType> CreateUserType([FromBody]UserType userType) => await userRepository.CreateUserType(userType);

        [HttpPost]
        [Route("user-log")]
        [SwaggerOperation(nameof(CreateUserLog))]
        [ProducesResponseType(typeof(UserLog), 201)]
        public async Task<UserLog> CreateUserLog([FromBody]UserLog userLog) => await userRepository.CreateUserLog(userLog);

        [HttpGet]
        [Route("user-account")]
        [SwaggerOperation(nameof(GetUserAccounts))]
        [ProducesResponseType(typeof(IEnumerable<UserAccount>), 200)]
        public IEnumerable<UserAccount> GetUserAccounts() => userRepository.GetUserAccounts();

        [HttpPost]
        [Route("user-account")]
        [SwaggerOperation(nameof(CreateUserAccount))]
        [ProducesResponseType(typeof(UserAccount), 201)]
        public async Task<UserAccount> CreateUserAccount([FromBody]UserAccount userAccount) => await userRepository.CreateUserAccount(userAccount);
    }
}