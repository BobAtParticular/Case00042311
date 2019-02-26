using NServiceBus;
using Case00042311;
using System;

class Program
{
    static void Main(string[] args)
    {
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Case00042311.NServiceBus5Sender");

        var transport = busConfiguration.UseTransport<RabbitMQTransport>();
        transport.ConnectionString("Host=localhost");

        busConfiguration.UseSerialization<BsonSerializer>();
        //busConfiguration.UseSerialization<JsonSerializer>();

        busConfiguration.UsePersistence<InMemoryPersistence>();

        var bus = Bus.CreateSendOnly(busConfiguration);

        Console.WriteLine("Press Enter key to send a message and exit.");
        Console.ReadLine();

        bus.Send("Case00042311.NServiceBus5Receiver", new TestCommand
        {
            Id = Guid.NewGuid()
        });

        bus.Dispose();
    }
}
