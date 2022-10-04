using Conflitec.Domain.Commads.Usuario;
using Conflitec.Domain.Core.Interfaces;
using Conflitec.Domain.Core.Notifications;
using Conflitec.Domain.Interfaces.Infra.Data;
using Conflitec.Domain.Interfaces.Infra.Data.Repositories;
using Conflitec.Infra.Bus;
using Conflitec.Infra.Data.Configuration;
using Conflitec.Infra.Data.Context;
using Conflitec.Infra.Data.EventSourcing;
using Conflitec.Infra.Data.Repositories.Usuario;
using Conflitec.Services.AppServices;
using Conflitec.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Conflitec.Infra.Ioc
{
    public class NativeInjector
    {
        public static void RegisterAppServices(IServiceCollection services)
        {
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Domain - Events
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventStore, EventStore>();
            services.AddDbContext<ConflitecDB>();
            services.AddScoped<ConflitecDB>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            //--------------------------------------------------------------------------------------------------------------------------
            ///Noticia
            //--------------------------------------------------------------------------------------------------------------------------
            // (Repositorio)  
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // (Application)
            services.AddScoped<IUsuarioAppService, UsuarioAppService>();

            //(Command)
            services.AddScoped<IRequestHandler<UsuarioCreateCommand, Unit>, UsuarioCommandHandler>();
            services.AddScoped<IRequestHandler<UsuarioEditCommand, Unit>, UsuarioCommandHandler>();

        }
    }
}
