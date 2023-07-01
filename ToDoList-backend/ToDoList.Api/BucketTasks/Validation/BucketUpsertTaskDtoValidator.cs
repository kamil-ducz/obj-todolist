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
            .Length(2, 15)
            .WithMessage("Bucket task name has to be between {MinLength}-{MaxLength} characters");
        
        RuleFor(d => d.Description)
            .MaximumLength(20)
            .WithMessage("Bucket task description has to be max {MaxLength} characters");
    }
}
