using FluentValidation;
using ToDoList.Api.BucketTasks.Models;

namespace ToDoList.Api.BucketTasks.Validation;

public class BucketUpsertTaskDtoValidator : AbstractValidator<BucketUpsertTaskDto>
{
    public BucketUpsertTaskDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("Bucket task cannot be empty")
            .MinimumLength(2)
            .MaximumLength(30)
            .WithMessage("Bucket task name has to be between 2-15 characters");
        RuleFor(d => d.Description)
            .MaximumLength(50)
            .WithMessage("Bucket task description has to be max 20 characters");
    }
}
