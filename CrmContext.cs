using DataverseConsoleApp.Configurations;
using Microsoft.PowerPlatform.Dataverse.Client;
using Microsoft.Extensions.Configuration;

namespace DataverseConsoleApp
{
    public static class CrmContext
    {
        public static ServiceClient GetOrganizationService()
        {
            try
            {
                var config = Program.Configuration.GetSection("CrmConfiguration").Get<CrmConfiguration>();

                var connectionString = $"AuthType=ClientSecret;Url={config.OrganizationUrl};ClientId={config.ClientId};ClientSecret={config.ClientSecret}";

                ServiceClient serviceClient = new ServiceClient(connectionString);

                // Verifica si la conexión es válida
                if (!serviceClient.IsReady)
                {
                    throw new Exception($"Failed to connect to CRM: {serviceClient.LastError}");
                }

                return serviceClient;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                throw;
            }
        }
    }
}
