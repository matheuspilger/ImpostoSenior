using ImpostoSenior.Infrastructure.Contexts.Interfaces;

namespace ImpostoSenior.Api.Extensions
{
    public static class ServiceProviderExtensions
    {
        public static void InitializeDatabase(this WebApplication app)
            => app.Services.GetRequiredService<IMongoDbContext>().Initialize();
    }
}