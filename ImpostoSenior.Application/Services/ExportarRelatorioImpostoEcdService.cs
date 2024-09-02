using ClosedXML.Excel;
using ImpostoSenior.Domain.Configurations;
using ImpostoSenior.Domain.Entities.Ecd.Imposto;
using ImpostoSenior.Domain.Filters.Ecd;
using ImpostoSenior.Domain.Helpers;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;
using ImpostoSenior.Domain.Interfaces.Services;
using Microsoft.Extensions.Options;
using System.Globalization;

namespace ImpostoSenior.Application.Services
{
    public class ExportarRelatorioImpostoEcdService(IRepositoryImpostoEcd repositoryImpostoEcd, IOptions<ReportConfig> options) : IExportarRelatorioImpostoEcdService
    {
        private readonly IRepositoryImpostoEcd _repositoryImpostoEcd = repositoryImpostoEcd;
        private readonly ReportConfig _reportConfig = options.Value;

        public async Task Export(FiltroCalculoImpostoEcd filter, CancellationToken cancellationToken)
        {
            var registrosImpostoEcd = await _repositoryImpostoEcd.GetMany(filter, cancellationToken);

            using var workbook = new XLWorkbook();
            var registrosPorMeses = registrosImpostoEcd.GroupBy(r => r.DataLancamento.ToString("MMyyyy")).OrderBy(r => r.Key);
            foreach (var registrosPorMes in registrosPorMeses)
            {
                var line = 0;
                var sheet = workbook.Worksheets.Add(registrosPorMes.Key);

                GenerateHeader(sheet, line += 1);
                
                foreach (var impostoEcd in registrosPorMes)
                    GenerateRow(sheet, impostoEcd, line += 1);
                
                GenerateFooter(sheet, line += 1, registrosPorMes.Select(r => r));
            }

            workbook.SaveAs(_reportConfig.FullPath(filter.Cnpj));
        }

        private void GenerateHeader(IXLWorksheet sheet, int line)
        {
            foreach (var item in ImpostoEcd.Propriedade.ListOfProperties())
            {
                var returnPosition = ReturnPositionColumn(item.Propriedade, line);
                sheet.Cell(returnPosition).Value = item.Propriedade;
            }
        }

        private void GenerateRow(IXLWorksheet sheet, ImpostoEcd impostoEcd, int line)
        {
            sheet.Cell(ReturnPositionColumn(nameof(ImpostoEcd.DataLancamento), line)).Value = impostoEcd.DataLancamento.ToString("dd/MM/yyyy");
            sheet.Cell(ReturnPositionColumn(nameof(ImpostoEcd.CodigoContabil), line)).Value = impostoEcd.CodigoContabil;
            sheet.Cell(ReturnPositionColumn(nameof(ImpostoEcd.ValorOriginal), line)).Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", impostoEcd.ValorOriginal);
            sheet.Cell(ReturnPositionColumn(nameof(ImpostoEcd.ValorCalculado), line)).Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", impostoEcd.ValorCalculado);
        }

        private void GenerateFooter(IXLWorksheet sheet, int line, IEnumerable<ImpostoEcd> registros)
        {
            sheet.Cell(ReturnPositionColumn(nameof(ImpostoEcd.ValorOriginal), line)).Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", registros.Sum(r => r.ValorOriginal));
            sheet.Cell(ReturnPositionColumn(nameof(ImpostoEcd.ValorCalculado), line)).Value = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", registros.Sum(r => r.ValorCalculado));
        }

        private string ReturnPositionColumn(string propertyName, int line) => ImpostoEcd.Propriedade.OfType(propertyName).GetColumnPosition(line);
    }
}
