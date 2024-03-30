using AppointmentSystem.Domain.Entities;
using FluentValidation;

namespace AppointmentSystem.Application.Validators
{
    public class PatientUserValidator : AbstractValidator<PatientUser>
    {
        public PatientUserValidator()
        {
            RuleFor(x => x.IdentifierNumber).MinimumLength(11).MaximumLength(11).NotEmpty().WithMessage("Lütfen kimliğinizi yazın.");
            RuleFor(x => x.Name).MinimumLength(2).NotEmpty().WithMessage("Bu alan minimum 2 karakter olmalıdır.");
            RuleFor(x => x.Surname).MinimumLength(2).NotEmpty().WithMessage("Bu alan minimum 2 karakter olmalıdır.");
            RuleFor(x => x.Email).EmailAddress().NotEmpty().WithMessage("Geçerli bir email girin.");
            RuleFor(x => x.Password).MinimumLength(5).NotEmpty().WithMessage("Bu alan minimum 5 karakter olmalıdır.");
            RuleFor(x => x.Address).MinimumLength(10).NotEmpty().WithMessage("Bu alan minimum 10 karakter olmalıdır.");
            RuleFor(x => x.Address).MinimumLength(10).NotEmpty().WithMessage("Bu alan minimum 10 karakter olmalıdır.");
        }
    }
}
