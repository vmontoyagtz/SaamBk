using Confluent.Kafka;

namespace KafkaCassandraService
{
    public class KafkaConsumerService : IDisposable
    {
        private readonly IConsumer<string, string> _consumer;

        public KafkaConsumerService(IConsumer<string, string> consumer)
        {
            _consumer = consumer;
        }

        public void StartConsuming(string topic)
        {
            _consumer.Subscribe(topic);

            CancellationTokenSource cts = new CancellationTokenSource();
            Console.CancelKeyPress += (_, e) =>
            {
                e.Cancel = true;
                cts.Cancel();
            };

            try
            {
                while (true)
                {
                    try
                    {
                        var consumeResult = _consumer.Consume(cts.Token);
                        Console.WriteLine($"Received message: {consumeResult.Message.Value} at {consumeResult.TopicPartitionOffset}");
                    }
                    catch (ConsumeException e)
                    {
                        Console.WriteLine($"Error consuming message: {e.Error.Reason}");
                    }
                }
            }
            catch (OperationCanceledException)
            {
                _consumer.Close();
            }
        }

        public void Dispose()
        {
            _consumer?.Dispose();
        }
    }

}
