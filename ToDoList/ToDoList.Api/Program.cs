using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ToDoList.Api.Assignee.Services;
using ToDoList.Api.Bucket.Services;
using ToDoList.Api.BucketTask.Services;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Stats.Services;
using ToDoList.Infrastructure.Interfaces;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // customer services and repositories

            builder.Services.AddSingleton<IAssigneeService, AssigneeService>();
            builder.Services.AddScoped<IBucketService, BucketService>();
            builder.Services.AddScoped<IBucketTaskService, BucketTaskService>();
            builder.Services.AddTransient<IStatsService, StatsService>();

            builder.Services.AddSingleton<IAssigneeRepository, AssigneeRepository>();
            builder.Services.AddScoped<IBucketRepository, BucketRepository>();
            builder.Services.AddScoped<IBucketTaskRepository, BucketTaskRepository>();
            builder.Services.AddTransient<IStatsRepository, StatsRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}