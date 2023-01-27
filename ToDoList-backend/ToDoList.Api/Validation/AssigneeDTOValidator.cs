using FluentValidation;
using ToDoList.Api.Asignee.Models;

namespace ToDoList.Api.Validation
{
    public class AssigneeDTOValidator : AbstractValidator<AssigneeDTO>
    {
        public AssigneeDTOValidator()
        {
            RuleFor(n => n.Name).NotEmpty();
            RuleFor(n => n.Name).MinimumLength(2).MaximumLength(20);
        }
    }
}
