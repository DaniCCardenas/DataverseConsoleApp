using DataverseConsoleApp;
using Microsoft.Extensions.Configuration;

public class Program
{
    public static IConfiguration Configuration { get; set; }

    static void Main(string[] args)
    {
        var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production";

        var builder = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true);
            

        Configuration = builder.Build();

        var service = CrmContext.GetOrganizationService();
        Console.WriteLine("Connected to CRM successfully!");
    }
}
