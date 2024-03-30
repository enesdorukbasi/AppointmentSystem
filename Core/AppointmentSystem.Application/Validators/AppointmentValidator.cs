using AppointmentSystem.Domain.Entities;
using FluentValidation;

namespace AppointmentSystem.Application.Validators
{
    public class AppointmentValidator : AbstractValidator<Appointment>
    {
        public AppointmentValidator()
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage("Bu alan zorunludur.");
            RuleFor(x => x.DoctorId).NotEmpty().WithMessage("Bu alan zorunludur.");
            RuleFor(x => x.IsClosedByDoctor).NotEmpty().WithMessage("Bu alan zorunludur.");
            RuleFor(x => x.IsCancelled).NotEmpty().WithMessage("Bu alan zorunludur.");
        }
    }
}
