using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Casino.Domain
{
    public static class Project
    {
        public static Assembly Assembly => typeof(Project).Assembly;

        public static IServiceCollection AddDomain(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly);
            services.AddMediatR(Assembly);
            return services;
        }
    }
}
