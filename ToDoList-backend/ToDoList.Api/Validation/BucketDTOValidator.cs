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
            RuleFor(d => d.Description).MaximumLength(15);
            RuleFor(t => t.MaxAmountOfTasks).NotEmpty();
            RuleFor(t => t.MaxAmountOfTasks).GreaterThanOrEqualTo(1)
                                            .LessThanOrEqualTo(15);
        }
    }
}
