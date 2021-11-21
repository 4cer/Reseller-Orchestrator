using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using ProITM.Client.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace ProITM.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddHttpClient("ProITM.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
                .AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();

            // Supply HttpClient instances that include access tokens when making requests to the server project
            builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ProITM.ServerAPI"));

            builder.Services.AddScoped<IContainerService, ContainerService>();
            builder.Services.AddScoped<IHostService, HostService>();
            builder.Services.AddScoped<IImageService, ImageService>();

            builder.Services.AddApiAuthorization();

            await builder.Build().RunAsync();
        }
    }
}
