using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.DTOs.DoctorUserDTOs;
using AppointmentSystem.Domain.Entities;
using AutoMapper;

namespace AppointmentSystem.Application.Mappings
{
    public class DoctorUserProfile : Profile
    {
        public DoctorUserProfile()
        {
            CreateMap<DoctorUser, DoctorUserLoginDTO>().ReverseMap();
            CreateMap<DoctorUser, DoctorUserListDTO>().ReverseMap();
        }
    }
}
