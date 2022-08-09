using FluentValidation;

namespace ToDoList.Api.Validation
{
    public class BucketValidator : AbstractValidator<Domain.Models.Bucket>
    {
        public BucketValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).MinimumLength(1);
            RuleFor(d => d.Description).MaximumLength(2000);
            RuleFor(t => t.MaxAmountOfTasks).NotEmpty();
            RuleFor(t => t.MaxAmountOfTasks).GreaterThanOrEqualTo(0)
                .LessThanOrEqualTo(40);
        }
    }
}
