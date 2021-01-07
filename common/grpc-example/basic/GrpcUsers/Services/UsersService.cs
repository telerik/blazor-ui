using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace GrpcUsers
{
    public class UsersService : Users.UsersBase
    {
        private readonly ILogger<UsersService> _logger;
        public UsersService(ILogger<UsersService> logger)
        {
            _logger = logger;
        }

        public override Task<UsersReply> GetUsers(UsersRequest request, ServerCallContext context)
        {
            IEnumerable<User> users = Enumerable.Range(1, 20).Select(
                x => new User { Id = x, Name = $"Name {x} from {request.DepartmentName}" });
            UsersReply response = new UsersReply();
            response.ListOfUsers.AddRange(users);
            return Task.FromResult(response);
        }
    }
}
