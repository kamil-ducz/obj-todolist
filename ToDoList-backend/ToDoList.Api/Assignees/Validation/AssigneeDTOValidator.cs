using FluentValidation;
using ToDoList.Api.Assignees.Models;

namespace ToDoList.Api.Assignees.Validation;

public class AssigneeDtoValidator : AbstractValidator<AssigneeDto>
{
    public AssigneeDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("Assignee name cannot be empty")
            .MinimumLength(2)
            .MaximumLength(20)
            .WithMessage("Assignee name has to be between 2-20 characters");
    }
}
