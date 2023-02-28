using Mediator.Command;
using Mediator.Query;
using Microsoft.Extensions.DependencyInjection;

namespace Mediator
{
    public static class MediatorInstaller
    {
        public static void AddMediator(this IServiceCollection services)
        {
            services.AddScoped<IQueryDispatcher, QueryDispatcher>();
            services.AddScoped<ICommandDispatcher, CommandDispatcher>();
        }
    }
}
