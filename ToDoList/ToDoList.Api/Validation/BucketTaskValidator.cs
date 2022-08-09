using FluentValidation;

namespace ToDoList.Api.Validation
{
    public class BucketTaskValidator : AbstractValidator<Domain.Models.BucketTask>
    {
        public BucketTaskValidator()
        {
            RuleFor(n => n.Name).NotEmpty();
            RuleFor(n => n.Name).MinimumLength(2).MaximumLength(100);
            RuleFor(d => d.Description).MaximumLength(2000);
        }
    }
}
