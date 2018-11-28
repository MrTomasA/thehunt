using System;
using Microsoft.Extensions.Logging;

namespace TheHunt.Service.Internal
{
    internal class UserService : IUserService
    {
        private readonly ILogger<UserService> logger;

        public UserService(ILogger<UserService> logger) => this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }
}