using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Net.Client;
using GrpcUsers;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                              new HelloRequest { Name = "GreeterClient" });
            Console.WriteLine("Greeting: " + reply.Message);

            var usersChannel = GrpcChannel.ForAddress("https://localhost:5001");
            var usersClient = new Users.UsersClient(usersChannel);
            var usersReply = await usersClient.GetUsersAsync(
                new UsersRequest { DepartmentName = "sales" });

            foreach (var item in usersReply.ListOfUsers)
            {
                Console.WriteLine(item.Name);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
