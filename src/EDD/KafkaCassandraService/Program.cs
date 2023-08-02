
using System.Reflection;
using Cassandra;

using Confluent.Kafka;
using KafkaCassandraService;
using KafkaCassandraService.Web.Interfaces;
using KafkaCassandraService.Web.Services;
using MediatR;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

builder.Services.AddControllersWithViews();

var siteSettings = configuration.GetSection("SiteSettings");
builder.Services.Configure<SiteConfiguration>(siteSettings);

var mailserverConfig = configuration.GetSection("Mailserver");
builder.Services.Configure<MailserverConfiguration>(mailserverConfig);

builder.Services.AddSingleton<ISendEmail, SmtpEmailSender>();
builder.Services.AddSingleton<ISendConfirmationEmails, ConfirmationEmailSender>();
builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

// Add these lines to configure Kafka and Cassandra
var kafkaConfig = configuration.GetSection("Kafka");
builder.Services.Configure<ProducerConfig>(kafkaConfig);

var cassandraConfig = configuration.GetSection("Cassandra");
builder.Services.Configure<Builder>(options => options.AddContactPoint(cassandraConfig["ContactPoints"])
        .WithCredentials(cassandraConfig["Username"], cassandraConfig["Password"])
        .WithPort(int.Parse(cassandraConfig["Port"]!)));

builder.Services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();

// Add these lines to register Kafka producer, consumer, and Cassandra session
builder.Services.AddSingleton<IProducer<string, string>>(sp =>
{
    var producerConfig = sp.GetRequiredService<IOptions<ProducerConfig>>().Value;
    return new ProducerBuilder<string, string>(producerConfig).Build();
});

builder.Services.AddSingleton<IConsumer<string, string>>(sp =>
{
    var consumerConfig = kafkaConfig.Get<ConsumerConfig>()!;
    consumerConfig.GroupId ??= Guid.NewGuid().ToString();
    return new ConsumerBuilder<string, string>(consumerConfig).Build();

});

builder.Services.AddSingleton<Cassandra.ISession>(sp =>
{
    var clusterBuilder = sp.GetRequiredService<IOptions<Builder>>().Value;
    return clusterBuilder.Build().Connect();
});
