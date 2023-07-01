using FluentValidation;
using ToDoList.Api.Buckets.Models;

namespace ToDoList.Api.Buckets.Validation;

public class BucketUpsertDtoValidator : AbstractValidator<BucketUpsertDto>
{
    public BucketUpsertDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("Bucket name cannot be empty")
            .Length(2, 20)
            .WithMessage("Bucket task name has to be between {MinLength}-{MaxLength} characters");
        
        RuleFor(d => d.Description)
            .MaximumLength(20)
            .WithMessage("Maximum description length is 15 characters");
        
        RuleFor(t => t.MaxAmountOfTasks)
            .NotEmpty()
            .WithMessage("Max amount of tasks cannot be empty");
        
        RuleFor(t => t.MaxAmountOfTasks)
            .InclusiveBetween(1, 15)
            .WithMessage("Max amount of tasks has to be between {From}-{To}");
    }
}
