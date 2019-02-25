using Case00042311;
using NServiceBus;
using System;

class Program
{
    static void Main(string[] args)
    {
        var busConfiguration = new BusConfiguration();
        busConfiguration.EndpointName("Case00042311.NServiceBus5Receiver");

        var transport = busConfiguration.UseTransport<RabbitMQTransport>();
        transport.ConnectionString("Host=localhost");

        busConfiguration.UseSerialization<BsonSerializer>();

        busConfiguration.UsePersistence<InMemoryPersistence>();

        busConfiguration.Conventions().DefiningCommandsAs(t => t == typeof(TestCommand));

        var startableBus = Bus.Create(busConfiguration);
        var bus = startableBus.Start();

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();

        bus.Dispose();
    }
}
