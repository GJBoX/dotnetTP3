using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using BlazorApp1.Services;
using System.Net.Http;
using BlazorApp1.Interface;

namespace BlazorApp1
{  
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            // Injection de HttpClient avec l'adresse de base de l'API pour WSServiceUtilisateur
            builder.Services.AddScoped(sp =>
                new HttpClient { BaseAddress = new Uri("http://localhost:5219/api/") });

            // Injection de IService<Utilisateur> en utilisant WSServiceUtilisateur
            builder.Services.AddScoped<IService<Utilisateur>, WSServiceUtilisateur>();

            await builder.Build().RunAsync();
        }
    }
}
