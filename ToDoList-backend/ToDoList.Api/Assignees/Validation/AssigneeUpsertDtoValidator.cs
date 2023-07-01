using FluentValidation;
using ToDoList.Api.Assignees.Models;

namespace ToDoList.Api.Assignees.Validation;

public class AssigneeUpsertDtoValidator : AbstractValidator<AssigneeUpsertDto>
{
    public AssigneeUpsertDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("Assignee name cannot be empty")
            .Length(2, 20)
            .WithMessage("Assignee name has to be between {MinLength}-{MaxLength} characters");
    }
}
