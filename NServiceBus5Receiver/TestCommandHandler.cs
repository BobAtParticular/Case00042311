using System;
using Case00042311;
using NServiceBus;

public class TestCommandHandler : IHandleMessages<TestCommand>
{
    public void Handle(TestCommand message)
    {
        throw new NotImplementedException();
    }
}

