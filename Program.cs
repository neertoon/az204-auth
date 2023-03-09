using System.Threading.Tasks;
using Microsoft.Identity.Client;

namespace az204_auth
{
    class Program {
        private const string _clientId = "APP_CLIENT_ID";
        private const string _tenantId = "DIR_TENANT_ID";

        public static async Task Main(string[] args) {
            var app = PublicClientApplicationBuilder
            .Create(_clientId)
            .WithAuthority(AzureCloudInstance.AzurePublic, _tenantId)
            .WithRedirectUri("http://localhost")
            .Build();

            string[] scopes = { "user.read" };

            AuthenticationResult result = await app.AcquireTokenInteractive(scopes).ExecuteAsync();

            Console.WriteLine($"Token:\t{result.AccessToken}");
        }
    }
}
