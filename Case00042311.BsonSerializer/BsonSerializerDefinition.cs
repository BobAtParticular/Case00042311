using System;
using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;
using NServiceBus.Settings;

namespace Case00042311.BsonSerializer
{
    public class BsonSerializer :
        SerializationDefinition
    {
        public override Func<IMessageMapper, IMessageSerializer> Configure(ReadOnlySettings settings)
        {
            return mapper => new BsonMessageSerializer(mapper);
        }
    }
}