using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Casino.Core.Interfaces.Repositories;
using Casino.DataAccess.DynamoDb.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Casino.DataAccess.DynamoDb
{
    public static class Project
    {
        public static Assembly Assembly => typeof(Project).Assembly;

        public static IServiceCollection AddDynamoDbDataStore(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDefaultAWSOptions(configuration.GetAWSOptions());
            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                var config = new AmazonDynamoDBConfig
                {
                    ServiceURL = configuration["AWS:ServiceURL"],
                    AuthenticationRegion = configuration["AWS:Region"]
                };
                return new AmazonDynamoDBClient(config);
            });

            services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IGameRecordRepository, GameRecordRepository>();
            services.AddAutoMapper(Assembly);

            return services;
        }
    }
}
