using SaamBlazor.UI.Client.Data;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using SaamBlazor.UI.Client;
using Syncfusion.Blazor;
using System.Globalization;
using Microsoft.JSInterop;
using SaamBlazor.UI.Client.Shared;
using Microsoft.AspNetCore.SignalR.Client;
using SaamBlazor.UI.Client.Common;
using SaamBlazor.UI.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddSyncfusionBlazor();
builder.Services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("en-US");
CultureInfo.DefaultThreadCurrentUICulture = new CultureInfo("en-US");
var host = builder.Build();
var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
var result = await jsInterop.InvokeAsync<string>("cultureInfo.get");
if (result != null)
{
    var culture = new CultureInfo(result);
    CultureInfo.DefaultThreadCurrentCulture = culture;
    CultureInfo.DefaultThreadCurrentUICulture = culture;
}
builder.Services.AddSingleton<RegionIdServices>();
builder.Services.AddSingleton<CountryIdService>();
builder.Services.AddSingleton<PdfService>();
builder.Services.AddSingleton<ExcelService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU5ODc1M0AzMjMyMmUzMDJlMzBvQURpQWlkdVV1QXVtVnd4VW5hTm9WYWNEWXZxMmJkK1EvWHNSWk5xcDFjPQ==;MjU5ODc1NEAzMjMyMmUzMDJlMzBhUlc4UkJLTzdwWU45NC8zR1pzWkpFNS80Qkd2S01CTkJkbjdFMUpCY3l3PQ==");






builder.Services.AddSingleton<BlazorServerSignalRService>();
builder.Services.AddSingleton<SaamApiSignalRService>();

await builder.Build().RunAsync();
