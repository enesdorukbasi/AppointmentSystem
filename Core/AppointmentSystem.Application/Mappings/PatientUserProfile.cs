using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Domain.Entities;
using AutoMapper;

namespace AppointmentSystem.Application.Mappings
{
    public class PatientUserProfile : Profile
    {
        public PatientUserProfile()
        {
            CreateMap<PatientUser,  PatientUserListDTO>().ReverseMap();
        }
    }
}
