using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using ToDoList.Api.Asignee.Models;
using ToDoList.Api.Assignee.Services;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.Bucket.Services;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.BucketTask.Services;
using ToDoList.Api.Interfaces;
using ToDoList.Api.Validation;
using ToDoList.Domain.Interfaces;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Api;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddControllers();
        builder.Services.AddCors();
        builder.Services.AddMvc();
        builder.Services.AddFluentValidationAutoValidation();

        builder.Services.AddScoped<IAssigneeService, AssigneeService>();
        builder.Services.AddScoped<IBucketService, BucketService>();
        builder.Services.AddScoped<IBucketTaskService, BucketTaskService>();

        builder.Services.AddScoped<IAssigneeRepository, AssigneeRepository>();
        builder.Services.AddScoped<IBucketRepository, BucketRepository>();
        builder.Services.AddScoped<IBucketTaskRepository, BucketTaskRepository>();

        builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        builder.Services.AddScoped<IValidator<AssigneeDto>, AssigneeDtoValidator>();
        builder.Services.AddScoped<IValidator<AssigneeInsertDto>, AssigneeInsertDtoValidator>();
        builder.Services.AddScoped<IValidator<BucketDto>, BucketDtoValidator>();
        builder.Services.AddScoped<IValidator<BucketInsertDto>, BucketInsertDtoValidator>();
        builder.Services.AddScoped<IValidator<BucketTaskDto>, BucketTaskDtoValidator>();
        builder.Services.AddScoped<IValidator<BucketInsertTaskDto>, BucketInsertTaskDtoValidator>();

        builder.Services.AddDbContext<ToDoListDbContext>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.UseCors(
            options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
            );

        app.MapControllers();

        app.Run();
    }
}