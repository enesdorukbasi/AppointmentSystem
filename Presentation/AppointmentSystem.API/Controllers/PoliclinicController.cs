using AppointmentSystem.Application.Extensions;
using AppointmentSystem.Application.Features.CQRS.Commands.PoliclinicCommands;
using AppointmentSystem.Application.Features.CQRS.Queries.PoliclinicQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AppointmentSystem.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PoliclinicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PoliclinicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPoliclinicQueryRequest());
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var response = await _mediator.Send(new GetByIdPoliclinicQueryRequest() { PoliclinicId = id });
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreatePoliclinicCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdatePoliclinicCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeletePoliclinicCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return this.ReturnResponseForIDtoExtension(response);
        }
    }
}
