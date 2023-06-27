﻿using FluentValidation;
using ToDoList.Api.Asignee.Models;

namespace ToDoList.Api.Assignee;

public class AssigneeUpsertDtoValidator : AbstractValidator<AssigneeUpsertDto>
{
    public AssigneeUpsertDtoValidator()
    {
        RuleFor(n => n.Name)
            .NotEmpty()
            .WithMessage("Assignee name cannot be empty");
        RuleFor(n => n.Name)
            .MinimumLength(2)
            .MaximumLength(20)
            .WithMessage("Assignee name has to be between 2-20 characters");
    }
}
