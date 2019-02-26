using System;
using NServiceBus;

namespace Case00042311
{
    public class TestCommand : ICommand
    {
        public Guid Id { get; set; }
    }
}
