using FluentValidation;
using ToDoList.Api.Stats.Models;

namespace ToDoList.Api.Validation
{
    public class StatsDTOValidator : AbstractValidator<StatsDTO>
    {
        public StatsDTOValidator()
        {
            RuleFor(s => s.AsigneeId).NotEmpty();
        }
    }
}
