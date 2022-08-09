using FluentValidation;

namespace ToDoList.Api.Validation
{
    public class AssigneeValidator : AbstractValidator<Domain.Models.Assignee>
    {
        public AssigneeValidator()
        {
            RuleFor(n => n.Name).NotEmpty();
            RuleFor(n => n.Name).MinimumLength(2).MaximumLength(20);
        }
    }
}
