using ChallengeSND.Business.Servicies;
using ChallengeSND.Business.Servicies.Interfaces;
using ChallengeSND.Web2.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ChallengeSND.Business.Profiles;
using ChallengeSND.Web2;
using MudBlazor.Services;


var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app"); 

// Registra el HttpClient que se usa en el MedicoService
builder.Services.AddHttpClient();
builder.Services.AddTransient<ApiService>();
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ChallengeSND.API"));

// Añade los servicios necesarios
builder.Services.AddScoped<IMedicoService, MedicoService>();
builder.Services.AddScoped<MedicoService>();
builder.Services.AddScoped<JwtAuthenticationStateProvider>();

// Configura la autenticación
builder.Services.AddAuthorizationCore();
// Configura MudBlazor
builder.Services.AddMudServices();

// Configura AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));

await builder.Build().RunAsync();
    