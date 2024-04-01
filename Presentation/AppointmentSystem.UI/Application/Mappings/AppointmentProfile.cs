using AppointmentSystem.UI.Application.DTOs;
using AppointmentSystem.UI.Domain.Models;
using AutoMapper;

namespace AppointmentSystem.UI.Application.Mappings
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, CreateAppointmentDTO>().ReverseMap();
            CreateMap<Appointment, UpdateAppointmentDTO>().ReverseMap();
        }
    }
}
