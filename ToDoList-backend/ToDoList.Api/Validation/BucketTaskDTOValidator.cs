using FluentValidation;
using ToDoList.Api.BucketTask.Models;

namespace ToDoList.Api.Validation;

public class BucketTaskDTOValidator : AbstractValidator<BucketTaskDto>
{
    public BucketTaskDTOValidator()
    {
        RuleFor(n => n.Name).NotEmpty();
        RuleFor(n => n.Name).MinimumLength(2).MaximumLength(15);
        RuleFor(d => d.Description).MaximumLength(250);
    }
}
