using AppointmentSystem.UI.Application.DTOs;
using AppointmentSystem.UI.Domain.Models;
using AutoMapper;

namespace AppointmentSystem.UI.Application.Mappings
{
    public class PoliclinicProfile : Profile
    {
        public PoliclinicProfile()
        {
            CreateMap<Policlinic, PoliclinicListDTO>().ReverseMap();
        }
    }
}
