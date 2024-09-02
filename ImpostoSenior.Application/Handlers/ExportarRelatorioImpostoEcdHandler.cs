using ImpostoSenior.Application.Dtos;
using ImpostoSenior.Application.Messages;
using ImpostoSenior.Domain.Filters.Ecd;
using ImpostoSenior.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImpostoSenior.Application.Handlers
{
    public record ExportarRelatorioImpostoEcdCommand(FiltroImpostoEcdDto Dto) : IRequest<IActionResult>;

    public class ExportarRelatorioImpostoEcdHandler(
        IExportarRelatorioImpostoEcdService exportarRelatorioImpostoEcdService, 
        ILogger<ExportarRelatorioImpostoEcdHandler> logger) : IRequestHandler<ExportarRelatorioImpostoEcdCommand, IActionResult>
    {
        private readonly IExportarRelatorioImpostoEcdService _exportarRelatorioImpostoEcdService = exportarRelatorioImpostoEcdService;
        private readonly ILogger<ExportarRelatorioImpostoEcdHandler> _logger = logger;

        public async Task<IActionResult> Handle(ExportarRelatorioImpostoEcdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var filter = FiltroCalculoImpostoEcd.Builder.Build(command.Dto.DataInicial, command.Dto.DataFinal, command.Dto.Cnpj, command.Dto.Hash);
                await _exportarRelatorioImpostoEcdService.Export(filter, cancellationToken);
                return new OkObjectResult(MessageConstant.OperacaoRealizadaComSucesso);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, MessageConstant.ErroAoExportarRelatorioImpostoEcd);
                return new BadRequestObjectResult(MessageConstant.ErroAoExportarRelatorioImpostoEcd);
            }
        }
    }
}
