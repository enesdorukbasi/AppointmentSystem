using AppointmentSystem.Application.Extensions;
using AppointmentSystem.Application.Features.CQRS.Commands.DoctorCommands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class DoctorUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DoctorUserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize]
        [HttpGet("{policlinicId}")]
        public async Task<IActionResult> GetAllDoctorsByPoliclinicId(int policlinicId = 0)
        {
            var response = await _mediator.Send(new GetAllDoctorsByPoliclinicIdCommandRequest() { PoliclinicId = policlinicId });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> LoginDoctor(LoginDoctorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterDoctor(CreateDoctorCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }
    }
}
