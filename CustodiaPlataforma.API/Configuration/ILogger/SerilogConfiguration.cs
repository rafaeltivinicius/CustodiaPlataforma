using Serilog;
using Serilog.Events;
using Serilog.Exceptions;

namespace CustodiaPlataforma.API.Configuration.ILogger
{
    public static class SerilogConfiguration
    {
        public static void CreateLogger()
        {
            Log.Logger = new LoggerConfiguration()
                                .MinimumLevel.Information()
                                .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                                .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
                                .Enrich.FromLogContext()
                                .Enrich.WithExceptionDetails()
                                .WriteTo.Console(outputTemplate: "[{Timestamp:HH:mm:ss} {Level:u3}] {Message:lj} {Properties} Exception: \"{Exception}\"{NewLine}")
                                .CreateLogger()
                                ;
        }
    }
}
