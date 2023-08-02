using System;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SaamApp.Api.Hubs;
using SaamApp.Infrastructure.Data.Sync;
using SaamApp.Infrastructure.Messaging;
using SaamAppLib.SharedKernel;

namespace SaamApp.Api
{
    public class BusinessManagementRabbitMqService : BackgroundService // entity-changes
    {
        private readonly string _exchangeName = MessagingConstants.Exchanges.SAAMAPP_BUSINESSMANAGEMENT_EXCHANGE;
        private readonly ILogger<BusinessManagementRabbitMqService> _logger;
        private readonly string _queuein = MessagingConstants.Queues.FDCM_SAAMAPP_IN;


        // BusinessManagementRabbitMqService:
        // //This service listens for messages from a RabbitMQ queue and sends a SignalR message to all connected clients when a message is received.
        // The SignalR message is sent with await _scheduleHub.Clients.All.SendAsync("ReceiveMessage",notification);.
        private readonly IHubContext<SaamAppHub>
            _scheduleHub;

        private readonly IServiceScopeFactory _serviceScopeFactory;
        private IModel _channel;
        private IConnection _connection;

        public BusinessManagementRabbitMqService(
            IOptions<RabbitMqConfiguration> rabbitMqOptions,
            ILogger<BusinessManagementRabbitMqService> logger,
            IServiceScopeFactory serviceScopeFactory,
            IHubContext<SaamAppHub> scheduleHub)
        {
            var settings = rabbitMqOptions.Value;
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _scheduleHub = scheduleHub;
            InitializeConnection(settings);
        }

        private void InitializeConnection(RabbitMqConfiguration settings)
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = settings.Hostname,
                    UserName = settings.UserName,
                    Password = settings.Password,
                    VirtualHost = settings.VirtualHost,
                    Port = settings.Port
                };
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();
                _channel.ExchangeDeclare(_exchangeName, "direct",
                    true,
                    false,
                    null);
                _channel.QueueDeclare(_queuein,
                    true,
                    false,
                    false,
                    null);
                var routingKey = "entity-changes";
                _channel.QueueBind(_queuein, _exchangeName, "entity-changes");
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
            _channel.BasicConsume(_queuein,
                true,
                consumer);
            return Task.CompletedTask;
        }

        private async void OnMessageReceived(object model, BasicDeliverEventArgs args)
        {
            var body = args.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            _logger.LogInformation(" [x] Received {0}", message);
            await HandleMessage(message);
        }

        private async Task HandleMessage(string message)
        {
            _logger.LogInformation($"Handling Message: {message}");
            using var doc = JsonDocument.Parse(message);
            var root = doc.RootElement;
            var eventType = root.GetProperty("EventType");
            var entity = root.GetProperty("Entity");
            using var scope = _serviceScopeFactory.CreateScope();
            var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
            if (eventType.GetString() == "Doctor-Created")
            {
                var id = entity.GetProperty("Id").GetInt32();
                var name = entity.GetProperty("Name").GetString();
                var command = new CreateDoctorCommand
                {
                    Id = id,
                    Name = name
                };
                await mediator.Send(command);
                var notification = $"New Doctor {name} added in Clinic Management. ";
                await _scheduleHub.Clients.All.SendAsync("ReceiveMessage", notification);
            }

            if (eventType.GetString() == "Client-Updated")
            {
                var id = entity.GetProperty("Id").GetInt32();
                var name = entity.GetProperty("Name").GetString();
                var command = new UpdateClientCommand
                {
                    Id = id,
                    Name = name
                };
                await mediator.Send(command);
                var notification = $"Client {name} updated in Clinic Management.";
                await _scheduleHub.Clients.All.SendAsync("ReceiveMessage", notification);
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