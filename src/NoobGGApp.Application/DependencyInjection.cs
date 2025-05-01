using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NoobGGApp.Application.Common.PipelineBehaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
namespace NoobGGApp.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());cfg.AddBehavior(typeof(IPipelineBehavior<,>), typeof(ValdiationBehavior<,>));});
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());


            return services;
        }
    }
}
