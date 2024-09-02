namespace ImpostoSenior.Domain.Configurations
{
    public class ReportConfig
    {
        public string Path { get; set; } = default!;
        public string Name { get; set; } = default!;

        public string FullPath(string custom) => $"{Path}{custom}-{Name}";
    }
}
