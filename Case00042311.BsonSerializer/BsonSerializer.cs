using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using NServiceBus.MessageInterfaces;
using NServiceBus.Serialization;

namespace Case00042311.BsonSerializer
{
    class BsonMessageSerializer :
        IMessageSerializer
    {
        readonly IMessageMapper messageMapper;

        readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings
        {
            TypeNameAssemblyFormatHandling = TypeNameAssemblyFormatHandling.Simple,
            TypeNameHandling = TypeNameHandling.Auto
        };

        public BsonMessageSerializer(IMessageMapper messageMapper)
        {
            this.messageMapper = messageMapper;
        }

        public void Serialize(object message, Stream stream)
        {
            var jsonSerializer = JsonSerializer.Create(serializerSettings);
            jsonSerializer.Binder = new MessageSerializationBinder(messageMapper);

            var jsonWriter = new BsonDataWriter(stream);

            var objects = new[]
            {
                message
            };
            jsonSerializer.Serialize(jsonWriter, objects);

            jsonWriter.Flush();
        }

        public object[] Deserialize(Stream stream, IList<Type> messageTypes = null)
        {
            throw new NotImplementedException();
        }

        public string ContentType { get; } = "application/bson";
    }
}