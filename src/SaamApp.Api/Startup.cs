using System;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using Autofac;
using Confluent.Kafka;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SaamApp.Api.Hubs;
using SaamApp.BlazorMauiShared;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Interfaces;
using SaamApp.Infrastructure;
using SaamApp.Infrastructure.Data;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace SaamApp.Api
{
    public class Startup
    {
        public const string CORS_POLICY = "CorsPolicy";
        private readonly IWebHostEnvironment _env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
            System.Diagnostics.Debug.WriteLine($"Environment: {_env.EnvironmentName}");

        }

        public IConfiguration Configuration { get; }

        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            ConfigureProductionServices(services);
        }

        public void ConfigureDockerServices(IServiceCollection services)
        {
            System.Diagnostics.Debug.WriteLine($"Environment: {_env.EnvironmentName}");
            ConfigureDevelopmentServices(services);
        }

        private void ConfigureInMemoryDatabases(IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(c =>
                c.UseInMemoryDatabase("AppDb"));
            ConfigureServices(services);
        }

        public void ConfigureProductionServices(IServiceCollection services)
        {

        
            string currentUserName = Environment.UserName;

            string connectionString = Configuration.GetConnectionString("DefaultConnection");

            if (currentUserName.Equals("macsaam", StringComparison.InvariantCultureIgnoreCase))
            {
                connectionString = Configuration.GetSection("ConnectionStrings:VictorConnection").Value;
            }
         

            services.AddDbContext<AppDbContext>(c =>
                c.UseSqlServer(connectionString));
            ConfigureServices(services);
        }

        public void ConfigureTestingServices(IServiceCollection services)
        {
            ConfigureInMemoryDatabases(services);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSignalR();
            services.AddMemoryCache();
            services.AddSingleton(typeof(IApplicationSettings), typeof(OfficeSettings));
            var baseUrlConfig = new BaseUrlConfiguration();
            Configuration.Bind(BaseUrlConfiguration.CONFIG_NAME, baseUrlConfig);
            services.AddCors(options => options.AddPolicy(CORS_POLICY,
                builder =>
                {
                    builder.WithOrigins(baseUrlConfig.WebBase.Replace("host.docker.internal", "localhost")
                        .TrimEnd('/'));
                    builder.SetIsOriginAllowed(origin => true);
                    builder.AllowAnyMethod();
                    builder.AllowAnyHeader();
                }));
            services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
                options.JsonSerializerOptions.WriteIndented = true;
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });
            var assemblies = new[]
            {
                typeof(Startup).Assembly,
                typeof(AppDbContext).Assembly,
                typeof(Invoice).Assembly
            };
            services.AddMediatR(assemblies);
            services.AddResponseCompression(opts => opts.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(
                new[] { "application/octet-stream" }));
            services.AddAutoMapper(typeof(Startup).Assembly);
            services.AddSwaggerGenCustom();
            services.AddSingleton<KafkaProducerService>();
            services.Configure<ProducerConfig>(Configuration.GetSection("KafkaProducerConfig"));
            services.AddSingleton(sp =>
            {
                var producerConfig = sp.GetRequiredService<IOptions<ProducerConfig>>().Value;
                return new ProducerBuilder<string, string>(producerConfig).Build();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var isDevelopment = _env.EnvironmentName == "Development";
            builder.RegisterModule(new DefaultInfrastructureModule(isDevelopment, Assembly.GetExecutingAssembly()));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseResponseCompression();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            // app.UseCors(CORS_POLICY);

            if (env.IsDevelopment())
            {
                app.UseCors(builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
            }
            else
            {
                app.UseCors(builder =>
                {
                    builder.WithOrigins("https://trustedwebsite.com") //  trusted origin
                        .WithMethods("GET", "POST") // needed methods
                        .WithHeaders("Authorization"); //  needed headers
                });
            }

            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "SaamApp V1");
                    c.RoutePrefix = string.Empty;
                    c.DocExpansion(DocExpansion.None);
                    c.EnableFilter("Customer");
                    c.EnableTryItOutByDefault();
                });
            }

            // app.UseEndpoints(endpoints => endpoints.MapControllers());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<SaamApiSignalrHub>("/saamApiSignalrHub"); // signalR hub
            });
        }
    }
}