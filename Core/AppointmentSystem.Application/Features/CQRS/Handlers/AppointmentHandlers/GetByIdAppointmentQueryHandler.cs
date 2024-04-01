using AppointmentSystem.Application.DTOs;
using AppointmentSystem.Application.Features.CQRS.Queries.AppointmentQueries;
using AppointmentSystem.Application.Interfaces;
using AppointmentSystem.Domain.Entities;
using AutoMapper;
using MediatR;

namespace AppointmentSystem.Application.Features.CQRS.Handlers.AppointmentHandlers
{
    public class GetByIdAppointmentQueryHandler : IRequestHandler<GetByIdAppointmentQueryRequest, IDTO<AppointmentListDTO?>>
    {
        private readonly IRepository<Appointment> _appointmentRepository;
        private readonly IMapper _mapper;

        public GetByIdAppointmentQueryHandler(IRepository<Appointment> appointmentRepository, IMapper mapper)
        {
            _appointmentRepository = appointmentRepository;
            _mapper = mapper;
        }

        public async Task<IDTO<AppointmentListDTO?>> Handle(GetByIdAppointmentQueryRequest request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _appointmentRepository.GetById(request.AppointmentId);
                if(response == null)
                {
                    return new IDTO<AppointmentListDTO?>(404, null, "Data bulunamadı.");
                }
                else
                {
                    var dto = _mapper.Map<AppointmentListDTO>(response);
                    return new IDTO<AppointmentListDTO?>(200, _mapper.Map<AppointmentListDTO>(response), "Data bulundu.");
                }
            }
            catch (Exception)
            {
                return new IDTO<AppointmentListDTO?>(500, null, "Bir sorun oluştu.");
            }
        }
    }
}
