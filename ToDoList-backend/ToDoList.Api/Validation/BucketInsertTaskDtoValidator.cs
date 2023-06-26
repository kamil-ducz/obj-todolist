using FluentValidation;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Validation;

public class BucketInsertTaskDtoValidator : AbstractValidator<BucketInsertTaskDto>
{
    public BucketInsertTaskDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("Bucket task cannot be empty");
        RuleFor(n => n.Name)
            .MinimumLength(2)
            .MaximumLength(15)
            .WithMessage("Bucket task name has to be between 2-15 characters");
        RuleFor(d => d.Description)
            .MaximumLength(20)
            .WithMessage("Bucket task description has to be max 20 characters");
    }
}
