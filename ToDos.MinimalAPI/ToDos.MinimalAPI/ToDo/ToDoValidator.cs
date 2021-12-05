using FluentValidation;

namespace ToDos.MinimalAPI;

public class ToDoValidator : AbstractValidator<ToDo>
{
    public ToDoValidator()
    {
        RuleFor(t => t.Value)
            .NotEmpty()
            .MinimumLength(5)
            .WithMessage("Wrong value kiddo. (Must be at least 5 characters.)");
    }
}

