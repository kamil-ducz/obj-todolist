using FluentValidation;
using ToDoList.Api.Buckets.Models;

namespace ToDoList.Api.Buckets.Validation;

public class BucketUpsertDtoValidator : AbstractValidator<BucketUpsertDto>
{
    public BucketUpsertDtoValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Bucket name cannot be empty");
        RuleFor(x => x.Name)
            .MinimumLength(2)
            .MaximumLength(30)
            .WithMessage("Bucket name has to be between 2-15 characters");
        RuleFor(d => d.Description)
            .MaximumLength(50)
            .WithMessage("Maximum description length is 15 characters");
        RuleFor(t => t.MaxAmountOfTasks)
            .NotEmpty()
            .WithMessage("Max amount of tasks cannot be empty");
        RuleFor(t => t.MaxAmountOfTasks)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(15)
            .WithMessage("Max amount of tasks has to be between 1-15");
    }
}
