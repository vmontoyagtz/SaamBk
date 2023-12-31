using System;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQMongoWatcher.Web.Models;

using SaamAppLib.SharedKernel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Reflection;

namespace RabbitMQMongoWatcher
{
    public class RabbitMQMongoService : BackgroundService // appointment-scheduled
    {
        private IModel _channel;
        private IConnection _connection;
        private readonly string _queuein = MessagingConstants.Queues.FDVCP_RABBITMQMONGOWATCHER_IN;
        private readonly string _exchangeName = MessagingConstants.Exchanges.SAAMAPP_RABBITMQMONGOWATCHER_EXCHANGE;
        private readonly ILogger<RabbitMQMongoService> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public RabbitMQMongoService(
          IOptions<RabbitMqConfiguration> rabbitMqOptions,
          ILogger<RabbitMQMongoService> logger,
          IServiceScopeFactory serviceScopeFactory)
        {
            var settings = rabbitMqOptions.Value;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            InitializeConnection(settings);
        }

        private void InitializeConnection(RabbitMqConfiguration settings)
        {
            try
            {
                // https://www.rabbitmq.com/tutorials/tutorial-six-dotnet.html#left-content

                _logger.LogInformation($"Connecting to RabbitMQ with {settings}");
                var factory = new ConnectionFactory
                {
                    HostName = settings.Hostname,
                    UserName = settings.UserName,
                    Password = settings.Password,
                    VirtualHost = settings.VirtualHost,
                    Port = settings.Port
                };
                //http://localhost:15672/
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(_exchangeName, "direct",
                                        durable: true,
                                        autoDelete: false,
                                        arguments: null);

                _channel.QueueDeclare(queue: _queuein,
                                    durable: true,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

                string routingKey = "appointment-scheduled";
                _channel.QueueBind(_queuein, _exchangeName, routingKey: routingKey);

                _logger.LogInformation($"*** Listening for messages on {_exchangeName}-{routingKey}...");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, settings.ToString());
                Thread.Sleep(5000); // let RabbitMQ service start in Docker Compose
                throw;
            }
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += OnMessageReceived;
            // https://www.rabbitmq.com/tutorials/tutorial-six-dotnet.html#left-content
            _channel.BasicConsume(queue: _queuein,
                          autoAck: true,
                          consumer: consumer);

            return Task.CompletedTask;
        }

        private async void OnMessageReceived(object model, BasicDeliverEventArgs args)
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            await HandleMessage(message);
        }


        private async Task HandleMessage(string message)
        {
            _logger.LogInformation($"Handling Message: {message}");

            var domainEvent = JsonConvert.DeserializeObject<OutBoxMessage>(
                message,
                new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All
                });

            var content = domainEvent.Content;
            var eventType = domainEvent.EventType!;
            var eventId = domainEvent.EventId!;
            var occurredOnUtc = domainEvent.OccurredOnUtc!;
            var actionOnMessageReceived = domainEvent.ActionOnMessageReceived!;

            var entityTypeStr =  domainEvent.EntityNameType!;






            var assemblyName = new AssemblyName("SaamApp.Domain");
            var assembly = Assembly.Load(assemblyName);

            string assemblyQualifiedName = "SaamApp.Domain.Entities." + entityTypeStr + ", SaamApp.Domain, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null";
            Type entityType = Type.GetType(assemblyQualifiedName);
            var entity = JsonConvert.DeserializeObject(content, entityType);


            using var scope = _serviceScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

            if (actionOnMessageReceived == "Mongo-History")
            {


                var command = new SendAppointmentConfirmationCommand()
                {
                    //AppointmentId = root.GetProperty("AppointmentId").GetGuid(),
                    //AppointmentType = root.GetProperty("AppointmentType").GetString(),
                    //ClientEmailAddress = root.GetProperty("ClientEmailAddress").GetString(),
                    //ClientName = root.GetProperty("ClientName").GetString(),
                    //DoctorName = root.GetProperty("DoctorName").GetString(),
                    //PatientName = root.GetProperty("PatientName").GetString(),
                    //AppointmentStartDateTime = root.GetProperty("AppointmentStartDateTime").GetDateTime()
                };
                // await mediator.Send(command);
            }
            else
            {
                //throw new Exception($"Unknown message type: {eventType.GetString()}");
            }

        }

        public override void Dispose()
        {
            _channel.Close();
            _channel.Dispose();
            _connection.Close();
            _connection.Dispose();
            base.Dispose();
        }
    }
}
