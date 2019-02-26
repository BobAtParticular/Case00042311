using Case00042311;
using NServiceBus;
using NServiceBus.Logging;

public class TestCommandHandler : IHandleMessages<TestCommand>
{
    public void Handle(TestCommand message)
    {
        Log.Info("Received a TestCommand message.");
    }

    private static readonly ILog Log = LogManager.GetLogger<TestCommandHandler>();
}

