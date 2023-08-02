using System.Collections.Generic;
using System.Reflection;
using Autofac;
using MediatR;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Interfaces;
using SaamApp.Infrastructure.Data;
using SaamApp.Infrastructure.Messaging;
using SaamAppLib.SharedKernel.Interfaces;
using Module = Autofac.Module;

namespace SaamApp.Infrastructure
{
    public class DefaultInfrastructureModule : Module
    {
        private readonly List<Assembly> _assemblies = new();
        private readonly bool _isDevelopment;

        public DefaultInfrastructureModule(bool isDevelopment, Assembly callingAssembly = null)
        {
            _isDevelopment = isDevelopment;
            var coreAssembly = Assembly.GetAssembly(typeof(Invoice));
            _assemblies.Add(coreAssembly);
            var infrastructureAssembly = Assembly.GetAssembly(typeof(AppDbContext));
            _assemblies.Add(infrastructureAssembly);
            if (callingAssembly != null)
            {
                _assemblies.Add(callingAssembly);
            }
        }

        protected override void Load(ContainerBuilder builder)
        {
            if (_isDevelopment)
            {
                RegisterDevelopmentOnlyDependencies(builder);
            }
            else
            {
                RegisterProductionOnlyDependencies(builder);
            }

            RegisterCommonDependencies(builder);
        }

        private void RegisterCommonDependencies(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(EfRepository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(EfRepository<>))
                .InstancePerLifetimeScope();

            // add a cache
            //notice for the IReadRepository we're actually wiring up a different type a cast repository this
            // acts as a decorator around the underlying EF repository and will
            // provide additional caching logic
            builder.RegisterGeneric(typeof(CachedRepository<>))
                .As(typeof(IReadRepository<>))
                .InstancePerLifetimeScope();
            builder.RegisterType<RabbitApplicationMessagePublisher>()
                .As<IApplicationMessagePublisher>()
                .InstancePerLifetimeScope();
            builder.Register<ServiceFactory>(context =>
            {
                var c = context.Resolve<IComponentContext>();
                return t => c.Resolve(t);
            });
            builder.RegisterType<EmailSender>().As<IEmailSender>()
                .InstancePerLifetimeScope();
        }

        private void RegisterDevelopmentOnlyDependencies(ContainerBuilder builder)
        {
        }

        private void RegisterProductionOnlyDependencies(ContainerBuilder builder)
        {
        }
    }
}