using System;
using System.Threading.Tasks;
using Case00042311;
using Newtonsoft.Json.Bson;
using NServiceBus;

class Program
{
    static async Task Main()
    {
        var endpointConfiguration = new EndpointConfiguration("Case00042311.NServiceBus7Sender");

        var transport = endpointConfiguration.UseTransport<RabbitMQTransport>();
        transport.ConnectionString("Host=localhost");
        transport.UseConventionalRoutingTopology();

        var serializer = endpointConfiguration.UseSerialization<NewtonsoftSerializer>();

        serializer.WriterCreator(stream => new BsonDataWriter(stream));
        serializer.ContentTypeKey("application/bson");

        endpointConfiguration.SendOnly();

        var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

        Console.WriteLine("Press Enter to send a message and exit");
        Console.ReadLine();

        await endpointInstance.Send("Case00042311.NServiceBus5Receiver", new TestCommand
        {
            Id = Guid.NewGuid()
        }).ConfigureAwait(false);

        await endpointInstance.Stop().ConfigureAwait(false);
    }
}
