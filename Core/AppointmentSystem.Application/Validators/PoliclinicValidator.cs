using AppointmentSystem.Domain.Entities;
using FluentValidation;

namespace AppointmentSystem.Application.Validators
{
    public class PoliclinicValidator : AbstractValidator<Policlinic>
    {
        public PoliclinicValidator()
        {
            RuleFor(x=>x.Definition).MinimumLength(2).NotEmpty().WithMessage("Bu alan minimum 2 karakter olmalıdır.");
        }
    }
}
