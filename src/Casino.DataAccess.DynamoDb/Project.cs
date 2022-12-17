using Amazon.DynamoDBv2;
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
            var config = new AmazonDynamoDBConfig
            {
                ServiceURL = configuration["DynamoDb:ServiceUrl"],
            };
            services.AddSingleton<IAmazonDynamoDB>(sp =>
            {
                return new AmazonDynamoDBClient(config);
            });
            return services; 
        }
    }
}
