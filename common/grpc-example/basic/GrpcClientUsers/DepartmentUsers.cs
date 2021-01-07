using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using Grpc.Net.Client;
using GrpcUsers;

namespace GrpcClientUsers
{
    public class DepartmentUsers
    {
        public static async Task<List<User>> GetUsersAsync(string deptName)
        {

            var usersChannel = GrpcChannel.ForAddress("https://localhost:5001");
            var usersClient = new Users.UsersClient(usersChannel);

            // for some reason the async version never returns on my end in a class library
            //var usersReply = await usersClient.GetUsersAsync(
            //    new UsersRequest { DepartmentName = deptName });

            var usersReply = usersClient.GetUsers(new UsersRequest { DepartmentName = deptName });

            List<User> users = new List<User>();
            foreach (var item in usersReply.ListOfUsers)
            {
                users.Add(item);
            }

            return await Task.FromResult(users);
        }
    }
}
