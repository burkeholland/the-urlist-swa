using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using TheUrlist.Infrastructure;
using Microsoft.ApplicationInsights.Extensibility;

[assembly: FunctionsStartup(typeof(TheUrlist.Startup))]
namespace TheUrlist
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<IBlackListChecker>(new EnvironmentBlackListChecker());
            builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddSingleton<ITelemetryInitializer, HeaderTelemetryInitializer>();
            builder.Services.AddSingleton<Hasher>();
        }
    }
}