using FluentValidation;

namespace Clean14000716.Application.Features.School.Commands.Create
{
    public class CreateSchoolCommandValidator : AbstractValidator<CreateSchoolCommand>
    {
        public CreateSchoolCommandValidator()
        {
            RuleFor(command => command.Name).MaximumLength(20).WithMessage("طول باید کمتر از 5 باشد");
        }
    }
}