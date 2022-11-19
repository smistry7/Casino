using Casino.Core.Interfaces.Repositories;
using Casino.DataAccess.Sql.Data;
using Casino.DataAccess.Sql.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.Sql
{
    public static class Project
    {
        public static Assembly Assembly => typeof(Project).Assembly;

        public static IServiceCollection AddSqlServerDataStore(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<CasinoDataContext>(options => options.UseSqlServer(config.GetConnectionString("SqlConnectionString")));
            services.AddAutoMapper(Assembly);
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGameRecordRepository, GameRecordRepository>();
            return services;
        }
    }
}
