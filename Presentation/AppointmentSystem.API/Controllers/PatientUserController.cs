using AppointmentSystem.Application.Extensions;
using AppointmentSystem.Application.Features.CQRS.Commands.PatientCommands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PatientUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> LoginPatient(LoginPatientCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterPatient(CreatePatientCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }
    }
}
