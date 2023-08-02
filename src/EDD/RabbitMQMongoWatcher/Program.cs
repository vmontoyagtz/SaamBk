using RabbitMQMongoWatcher;

using Microsoft.Extensions.ObjectPool;
using RabbitMQ.Client;
using RabbitMQMongoWatcher.Web.Interfaces;
using RabbitMQMongoWatcher.Web.Services;

using MediatR;
using System.Reflection;

using SaamAppLib.SharedKernel.Interfaces;

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

var messagingConfig = configuration.GetSection("RabbitMq");
var messagingSettings = messagingConfig.Get<RabbitMqConfiguration>();
builder.Services.Configure<RabbitMqConfiguration>(messagingConfig);
builder.Services.AddSingleton<IApplicationMessagePublisher, RabbitApplicationMessagePublisher>();
builder.Services.AddSingleton<ObjectPoolProvider, DefaultObjectPoolProvider>();
builder.Services.AddSingleton<IPooledObjectPolicy<IModel>, RabbitModelPooledObjectPolicy>();

if (messagingSettings.Enabled)
{
    builder.Services.AddHostedService<RabbitMQMongoService>();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
