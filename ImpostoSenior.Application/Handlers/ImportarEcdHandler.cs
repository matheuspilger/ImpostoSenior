using ImpostoSenior.Application.Dtos;
using ImpostoSenior.Application.Messages;
using ImpostoSenior.Domain.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ImpostoSenior.Application.Handlers
{
    public record ImportEcdCommand(ImportarDto Dto) : IRequest<IActionResult>;

    public class ImportEcdHandler(
        IProcessarArquivoEcdService processFileEcdService,
        ILogger<ExportarRelatorioImpostoEcdHandler> logger) : IRequestHandler<ImportEcdCommand, IActionResult>
    {
        private readonly IProcessarArquivoEcdService _processFileEcdService = processFileEcdService;
        private readonly ILogger<ExportarRelatorioImpostoEcdHandler> _logger = logger;

        public async Task<IActionResult> Handle(ImportEcdCommand command, CancellationToken cancellationToken)
        {
            try
            {
                var allLines = await File.ReadAllLinesAsync(command.Dto.FilePath, cancellationToken);
                await _processFileEcdService.Process(allLines, cancellationToken);
                return new OkObjectResult(MessageConstant.OperacaoRealizadaComSucesso);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, MessageConstant.ErroAoImportarEcd);
                return new BadRequestObjectResult(MessageConstant.ErroAoImportarEcd);
            }
        }
    }
}