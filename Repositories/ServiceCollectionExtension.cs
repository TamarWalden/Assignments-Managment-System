using Microsoft.Extensions.DependencyInjection;
using Repositories.Entities;
using Repositories.Interfaces;
using Repositories.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Repositories
{
    public static class ServiceCollectionExtension
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Assignment>, AssignmentRepository>();
            services.AddScoped<IRepository<AssignmentType>, AssignmentTypeRepository>();
        }
    }
}
