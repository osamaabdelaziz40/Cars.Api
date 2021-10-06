using Cars.Application.Interfaces;
using Cars.Application.Services;
using Cars.Domain.Commands.Customers;
using Cars.Domain.Core.Events;
using Cars.Domain.Events.Customer;
using Cars.Domain.Interfaces;
using Cars.DomainHelper.Interfaces;
using Cars.DomainHelper.Services;
using Cars.Infra.CrossCutting.Bus;
using Cars.Infra.Data.Repository;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Cars.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ICallHttpRequest, CallHttpRequest>();

            // Application
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<ICarTypeAppService, CarTypeAppService>();
          
            // Domain - Events
            services.AddScoped<INotificationHandler<CustomerRegisteredEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerUpdatedEvent>, CustomerEventHandler>();
            services.AddScoped<INotificationHandler<CustomerRemovedEvent>, CustomerEventHandler>();

            //services.AddScoped<INotificationHandler<BankAddEvent>, BankEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCustomerCommand, ValidationResult>, CustomerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveCustomerCommand, ValidationResult>, CustomerCommandHandler>();

            // Infra - Data
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<ICarTypeRepository, CarTypeRepository>();
            
            // Infra - Data EventSourcing
            //services.AddScoped<IEventStoreRepository, EventStoreSqlRepository>();
            //services.AddScoped<IEventStore, SqlEventStore>();
            //services.AddScoped<EventStoreSqlContext>();

            //Services
            services.AddScoped<ICSVManager, CSVManager>();




        }
    }
}