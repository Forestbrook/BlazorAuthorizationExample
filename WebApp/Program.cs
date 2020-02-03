using System;
using System.Net.Http;
using System.Threading.Tasks;
using BlazorExample.WebApp.Services;
using Microsoft.AspNetCore.Blazor.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace BlazorExample.WebApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            // Authorization
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<ClientAuthorizationService>(CreateAuthorizationService);
            builder.Services.AddScoped<AuthenticationStateProvider>(sp => sp.GetRequiredService<ClientAuthorizationService>());
            builder.Services.AddOptions();

            builder.RootComponents.Add<App>("app");
            var host = builder.Build();

            // TODO: Load initial language

            await host.RunAsync();
        }

        private static ClientAuthorizationService CreateAuthorizationService(IServiceProvider serviceProvider)
        {
            var httpClient = serviceProvider.GetRequiredService<HttpClient>();
            var service = new ClientAuthorizationService(httpClient)
            {
                ApiUriGetAuthorizedUser = "api/settings/user",

                // The SignIn and SignOut uris depend on the authentication provider you use.
                // In this example we assume Azure AD B2C (not yet implemented in the Api).
                ApiUriSignIn = "AzureADB2C/Account/SignIn",
                ApiUriSignOut = "AzureADB2C/Account/SignOut",
            };

            return service;
        }
    }
}
