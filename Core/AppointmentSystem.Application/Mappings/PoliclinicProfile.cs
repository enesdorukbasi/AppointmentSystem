using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.DTOs.PoliclinicDTOs;
using AppointmentSystem.Domain.Entities;
using AutoMapper;

namespace AppointmentSystem.Application.Mappings
{
    public class PoliclinicProfile : Profile
    {
        public PoliclinicProfile()
        {
            CreateMap<Policlinic, PoliclinicListDTO>().ReverseMap();
            CreateMap<Policlinic, PoliclinicByDoctorDTO>().ReverseMap();
        }
    }
}
