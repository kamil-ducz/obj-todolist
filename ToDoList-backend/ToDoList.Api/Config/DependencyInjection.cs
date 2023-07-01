﻿using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoList.Api.Assignee;
using ToDoList.Api.Assignee.Models;
using ToDoList.Api.Assignee.Services;
using ToDoList.Api.Assignee.Validation;
using ToDoList.Api.Bucket;
using ToDoList.Api.Bucket.Models;
using ToDoList.Api.Bucket.Services;
using ToDoList.Api.Bucket.Validation;
using ToDoList.Api.BucketTask;
using ToDoList.Api.BucketTask.Models;
using ToDoList.Api.BucketTask.Services;
using ToDoList.Api.BucketTask.Validation;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Repositories;
using ToDoList.Infrastructure;
using ToDoList.Infrastructure.Repositories;

namespace ToDoList.Api.Config;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        services.AddControllers();
        services.AddCors();
        services.AddMvc();
        services.AddFluentValidationAutoValidation();

        services.AddScoped<IAssigneeService, AssigneeService>();
        services.AddScoped<IBucketService, BucketService>();
        services.AddScoped<IBucketTaskService, BucketTaskService>();
        services.AddScoped<IBucketColorService, BucketColorService>();
        services.AddScoped<IBucketCategoryService, BucketCategoryService>();

        services.AddScoped<IAssigneeRepository, AssigneeRepository>();
        services.AddScoped<IBucketRepository, BucketRepository>();
        services.AddScoped<IBucketTaskRepository, BucketTaskRepository>();
        services.AddScoped<IBucketCategoryRepository, BucketCategoryRepository>();
        services.AddScoped<IBucketColorRepository, BucketColorRepository>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddScoped<IValidator<AssigneeDto>, AssigneeDtoValidator>();
        services.AddScoped<IValidator<AssigneeUpsertDto>, AssigneeUpsertDtoValidator>();
        services.AddScoped<IValidator<BucketDto>, BucketDtoValidator>();
        services.AddScoped<IValidator<BucketUpsertDto>, BucketUpsertDtoValidator>();
        services.AddScoped<IValidator<BucketTaskDto>, BucketTaskDtoValidator>();
        services.AddScoped<IValidator<BucketUpsertTaskDto>, BucketUpsertTaskDtoValidator>();

        services.AddDbContext<ToDoListDbContext>();

        return services;
    }
}
