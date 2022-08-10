using FluentValidation;
using ToDoList.Api.Bucket.Models;

namespace ToDoList.Api.Validation
{
    public class BucketDTOValidator : AbstractValidator<BucketDTO>
    {
        public BucketDTOValidator()
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
