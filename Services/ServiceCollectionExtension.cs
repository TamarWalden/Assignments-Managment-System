using DBAssignmentsContext;
using Microsoft.Extensions.DependencyInjection;
using Repositories;
using Services.Interfaces;
using Services.Services;

namespace Services
{
    public static class ServiceCollectionExtension
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<IAssignmentService, AssignmentService>();
            services.AddSingleton<IContext, AssignmentsContext>();
            services.AddAutoMapper(typeof(Mapper));
        }
    }
}