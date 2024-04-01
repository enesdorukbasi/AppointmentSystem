using AppointmentSystem.Application.Extensions;
using AppointmentSystem.Application.Features.CQRS.Commands.AppointmentCommands;
using AppointmentSystem.Application.Features.CQRS.Queries.AppointmentQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.API.Controllers
{
    [Authorize]
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

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdAppointmentQueryRequest() { AppointmentId = id });
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpPost()]
        public async Task<IActionResult> Create(CreateAppointmentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpPut()]
        public async Task<IActionResult> Update(UpdateAppointmentCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _mediator.Send(new DeleteAppointmentCommandRequest() { AppointmentID = id });
            return this.ReturnResponseForIDtoExtension(response);
        }
    }
}
