using AppointmentSystem.Application.Extensions;
using AppointmentSystem.Application.Features.CQRS.Commands.DoctorCommands;
using MediatR;
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
