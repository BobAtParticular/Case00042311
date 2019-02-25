using System.Threading.Tasks;
using NServiceBus;
using NServiceBus.MessageMutator;

class BsonContentTypeMutator : IMutateOutgoingTransportMessages
{
    public Task MutateOutgoing(MutateOutgoingTransportMessageContext context)
    {
        context.OutgoingHeaders[Headers.ContentType] = "application/bson";
        return Task.CompletedTask;
    }
}
