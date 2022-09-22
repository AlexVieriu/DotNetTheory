using Grpc.Net.Client;
using GrpcDemo;

var channel = GrpcChannel.ForAddress("http://localhost:5219");
var client = new Greeter.GreeterClient(channel);

var reply = await client.SayHelloAsync(
    new HelloRequest { Name = ",NET Conf" });
Console.WriteLine("From server:" + reply.Message);