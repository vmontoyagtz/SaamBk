using System;
using System.Text;
using System.Text.Json;
using Ardalis.GuardClauses;
using RabbitMQMongoWatcher.Web.Interfaces;
using RabbitMQMongoWatcher.Web.Models;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;
using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;

namespace RabbitMQMongoWatcher.Web.Services
{
    public class RabbitApplicationMessagePublisher : IApplicationMessagePublisher // appointment-confirmation
    {
        private readonly DefaultObjectPool<IModel> _objectPool;

        public RabbitApplicationMessagePublisher(IPooledObjectPolicy<IModel> objectPolicy)
        {
            _objectPool = new DefaultObjectPool<IModel>(objectPolicy, Environment.ProcessorCount * 2);
        }

        public void Publish(BaseDomainEvent baseDomainEvent)
        {
            Guard.Against.Null(baseDomainEvent, nameof(baseDomainEvent));

            var channel = _objectPool.Get();

            object message = (object)baseDomainEvent;

            // https://www.rabbitmq.com/tutorials/tutorial-six-dotnet.html#left-content
            try
            {
                string exchangeName = MessagingConstants.Exchanges.SAAMAPP_RABBITMQMONGOWATCHER_EXCHANGE;
                channel.ExchangeDeclare(exchangeName, "direct", true, false, null);

                var sendBytes = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));

                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;


                channel.BasicPublish(
                  exchange: exchangeName,
                  routingKey: "appointment-confirmation",
                  basicProperties: properties,
                  body: sendBytes);
            }
            finally
            {
                _objectPool.Return(channel);
            }
        }
    }
}
