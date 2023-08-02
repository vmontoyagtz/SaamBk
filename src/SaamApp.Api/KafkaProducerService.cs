using System;
using System.Threading.Tasks;
using Confluent.Kafka;

namespace SaamApp.Api
{
    public class KafkaProducerService
    {
        private readonly IProducer<string, string> _producer;

        public KafkaProducerService(IProducer<string, string> producer)
        {
            _producer = producer;
        }

        public async Task ProduceMessageAsync(string topic, string key, string message)
        {
            try
            {
                var deliveryResult =
                    await _producer.ProduceAsync(topic, new Message<string, string> { Key = key, Value = message });
                Console.WriteLine($"Message delivered to: {deliveryResult.TopicPartitionOffset}");
            }
            catch (ProduceException<string, string> e)
            {
                Console.WriteLine($"Failed to deliver message: {e.Error.Reason}");
            }
        }
    }
}