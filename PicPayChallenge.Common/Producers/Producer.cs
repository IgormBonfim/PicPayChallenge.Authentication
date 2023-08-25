using Confluent.Kafka;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using PicPayChallenge.Common.Producers.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PicPayChallenge.Common.Producers
{
    public class Producer<T> : IProducer<T> where T : class
    {
        private readonly string server;
        private readonly string topic;

        public Producer(IConfiguration configuration, string topic)
        {
            server = configuration.GetSection("Kafka:Url").Value!;
            this.topic = topic;
        }
        public T sendMessage(T fact)
        {
            Message<string, string> message = new Message<string, string>
            {
                Key = Guid.NewGuid().ToString(),
                Value = JsonSerializer.Serialize(fact),
            };

            var configs = new ProducerConfig
            {
                BootstrapServers = server
            };

            using (var producer = new ProducerBuilder<string, string>(configs).Build())
            {
                var result = producer.ProduceAsync(topic, message);
            }

            return fact;
        }
    }
}
