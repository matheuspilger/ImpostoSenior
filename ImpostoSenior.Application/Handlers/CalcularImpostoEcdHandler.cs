using ImpostoSenior.Application.Dtos;
using ImpostoSenior.Application.Messages;
using ImpostoSenior.Domain.Filters.Ecd;
using ImpostoSenior.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImpostoSenior.Application.Handlers
{
    public record CalcularImpostoEcdCommand(FiltroImpostoEcdDto Dto) : IRequest<IActionResult>;

    public class CalcularImpostoEcdHandler(
        ICalcularImpostoEcdService calcularImpostoEcdService,
        ILogger<ExportarRelatorioImpostoEcdHandler> logger) : IRequestHandler<CalcularImpostoEcdCommand, IActionResult>
    {
        private readonly ICalcularImpostoEcdService _calcularImpostoEcdService = calcularImpostoEcdService;
        private readonly ILogger<ExportarRelatorioImpostoEcdHandler> _logger = logger;

        public async Task<IActionResult> Handle(CalcularImpostoEcdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var filter = FiltroCalculoImpostoEcd.Builder.Build(command.Dto.DataInicial, command.Dto.DataFinal, command.Dto.Cnpj, command.Dto.Hash);
                await _calcularImpostoEcdService.Calculate(filter, cancellationToken);
                return new OkObjectResult(MessageConstant.OperacaoRealizadaComSucesso);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, MessageConstant.ErroAoRealizadorCalculoImpostoEcd);
                return new BadRequestObjectResult(MessageConstant.ErroAoRealizadorCalculoImpostoEcd);
            }
        }
    }
}
