using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using ToDoList.Api.Assignees.Models;
using ToDoList.Api.Assignees.Services;
using ToDoList.Api.Assignees.Validation;
using ToDoList.Api.Buckets.Models;
using ToDoList.Api.Buckets.Services;
using ToDoList.Api.Buckets.Validation;
using ToDoList.Api.BucketTasks.Models;
using ToDoList.Api.BucketTasks.Services;
using ToDoList.Api.BucketTasks.Validation;
using ToDoList.Api.Dictionaries.Services;
using ToDoList.Domain.Repositories;
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
        services.AddScoped<IBucketCategoryService, BucketCategoryService>();
        services.AddScoped<IBucketColorService, BucketColorService>();
        services.AddScoped<IBucketTaskService, BucketTaskService>();
        services.AddScoped<IBucketTaskStateService, BucketTaskStateService>();
        services.AddScoped<IBucketTaskPriorityService, BucketTaskPriorityService>();
        services.AddScoped<IDictionaryService, DictionaryService>();

        services.AddScoped<IAssigneeRepository, AssigneeRepository>();
        services.AddScoped<IBucketRepository, BucketRepository>();
        services.AddScoped<IBucketCategoryRepository, BucketCategoryRepository>();
        services.AddScoped<IBucketColorRepository, BucketColorRepository>();
        services.AddScoped<IBucketTaskRepository, BucketTaskRepository>();
        services.AddScoped<IBucketTaskStateRepository, BucketTaskStateRepository>();
        services.AddScoped<IBucketTaskPriorityRepository, BucketTaskPriorityRepository>();
        services.AddScoped<IDictionaryRepository, DictionaryRepository>();

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
