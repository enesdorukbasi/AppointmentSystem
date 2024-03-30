using AppointmentSystem.Application.Extensions;
using AppointmentSystem.Application.Features.CQRS.Queries.AppointmentQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AppointmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{doctorId}")]
        public async Task<IActionResult> GetAllByDoctorId(int doctorId)
        {
            var response = await _mediator.Send(new GetAllAppointmentsByDoctorIdQueryRequest() { DoctorId = doctorId });
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpGet("{patientId}")]
        public async Task<IActionResult> GetAllByPatientId(int patientId)
        {
            var response = await _mediator.Send(new GetAllAppointmentsByPatientIdQueryRequest() { PatientId = patientId });
            return this.ReturnResponseForIDtoExtension(response);
        }
    }
}
