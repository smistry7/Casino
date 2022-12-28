using Casino.Api.Authorisation;
using Casino.Api.Middlewares;
using Casino.Core.Extensions;
using Casino.DataAccess.DynamoDb;
using Casino.DataAccess.Sql;
using Casino.Domain;
using Casino.Domain.User.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Casino.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "Casino API", Version = "v1" });
            });
            switch (builder.Configuration["DataStore"])
            {
                case "DynamoDb":
                    builder.Services.AddDynamoDbDataStore(builder.Configuration);
                    break;
                case "Sql":
                default:
                    builder.Services.AddSqlServerDataStore(builder.Configuration);
                    break;
            }
            builder.Services
                .AddHealthChecks()
                .AddSqlServer(builder.Configuration.GetConnectionString("SqlConnectionString"));

            builder.Services.AddDomain();
            builder.Services.AddMediatR(typeof(Program).Assembly);
            builder.Services.AddAutoMapper(typeof(Program).Assembly);

            builder.Services.AddAuthentication("BasicAuthentication")
                .AddScheme<AuthenticationSchemeOptions, BasicAuthenticationHandler>("BasicAuthentication", null);

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "Casino API V1"); });
                app.UseDeveloperExceptionPage();
            }
            app.UseMiddleware<ErrorMiddleware>();
            app.UseHttpsRedirection();
            app.MapHealthChecks("health", new HealthCheckOptions
            {
                AllowCachingResponses = true,
            });
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}