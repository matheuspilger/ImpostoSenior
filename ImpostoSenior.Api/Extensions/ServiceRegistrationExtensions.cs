using ImpostoSenior.Application.Handlers;
using ImpostoSenior.Application.Services;
using ImpostoSenior.Domain.Configurations;
using ImpostoSenior.Domain.Interfaces.Repositories.Ecd;
using ImpostoSenior.Domain.Interfaces.Services;
using ImpostoSenior.Infrastructure.Contexts;
using ImpostoSenior.Infrastructure.Contexts.Interfaces;
using ImpostoSenior.Infrastructure.Repositories.Ecd;

namespace ImpostoSenior.Api.Extensions
{
    public static class ServiceRegistrationExtensions
    {
        public static IServiceCollection RegisterDependencies(this IServiceCollection services, IConfiguration configuration)
            => services
                .RegisterConfigs(configuration)
                .RegisterMediatR()
                .RegisterMongoDb()
                .RegisterServices()
                .RegisterRepositories();

        private static IServiceCollection RegisterConfigs(this IServiceCollection services, IConfiguration configuration)
            => services
                .Configure<DatabaseConfig>(configuration.GetSection(OptionsPath.Database))
                .Configure<ReportConfig>(configuration.GetSection(OptionsPath.Report));

        private static IServiceCollection RegisterMediatR(this IServiceCollection services)
            => services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ImportEcdCommand).Assembly));

        private static IServiceCollection RegisterMongoDb(this IServiceCollection services)
            => services.AddSingleton<IMongoDbContext, MongoDbContext>();

        private static IServiceCollection RegisterServices(this IServiceCollection services)
            => services
                .AddScoped<IProcessarArquivoEcdService, ProcessarArquivoEcdService>()
                .AddScoped<ICalcularImpostoEcdService, CalcularImpostoEcdService>()
                .AddScoped<IExportarRelatorioImpostoEcdService, ExportarRelatorioImpostoEcdService>();

        private static IServiceCollection RegisterRepositories(this IServiceCollection services)
            => services
                .AddScoped<IRepositoryC040, RepositoryC040>()
                .AddScoped<IRepositoryI200, RepositoryI200>()
                .AddScoped<IRepositoryEcd, RepositoryEcd>()
                .AddScoped<IRepositoryImpostoEcd, RepositoryImpostoEcd>();
    }
}