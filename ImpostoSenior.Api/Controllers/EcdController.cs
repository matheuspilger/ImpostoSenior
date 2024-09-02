using ImpostoSenior.Application.Handlers;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ImpostoSenior.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EcdController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpPost(nameof(ImportarEcd))]
        public async Task<IActionResult> ImportarEcd([FromQuery] ImportEcdCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpPost(nameof(CalcularImpostoEcd))]
        public async Task<IActionResult> CalcularImpostoEcd([FromQuery] CalcularImpostoEcdCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpGet(nameof(ExportarRelatorioImpostoEcd))]
        public async Task<IActionResult> ExportarRelatorioImpostoEcd([FromQuery] ExportarRelatorioImpostoEcdCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
