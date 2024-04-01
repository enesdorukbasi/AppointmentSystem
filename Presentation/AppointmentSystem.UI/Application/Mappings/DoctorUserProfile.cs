using AppointmentSystem.UI.Application.DTOs;
using AppointmentSystem.UI.Domain.Models;
using AutoMapper;

namespace AppointmentSystem.UI.Application.Mappings 
{
    public class DoctorUserProfile : Profile
    {
        public DoctorUserProfile()
        {
            CreateMap<DoctorUser, DoctorUserListDTO>().ReverseMap();
            CreateMap<DoctorUser, DoctorUserForAppointmentDTO>().ReverseMap();
        }
    }
}
