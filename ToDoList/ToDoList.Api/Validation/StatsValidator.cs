using FluentValidation;

namespace ToDoList.Api.Validation
{
    public class StatsValidator : AbstractValidator<Domain.Models.Stats>
    {
        public StatsValidator()
        {
            RuleFor(s => s.AsigneeId).NotEmpty();
        }
    }
}
