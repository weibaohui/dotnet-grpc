using System;
using System.Threading.Tasks;
using Grpc.Net.Client;
using grpcclient;

namespace clientgrpc
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // The port number(5001) must match the port of the gRPC server.
            using var channel = GrpcChannel.ForAddress("http://192.168.31.243:5000");
            var       client  =  new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloByIDAsync(
                new HelloRequest { Name = "xxxx" });
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
