using SaamBlazor.UI.Server.Common;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllersWithViews().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
            });
builder.Services.AddMemoryCache();
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyPolicy", builder =>
    {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});
;
builder.Services.AddRazorPages();

builder.Services.AddSignalR(); // Add SignalR services

Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU5ODc1M0AzMjMyMmUzMDJlMzBvQURpQWlkdVV1QXVtVnd4VW5hTm9WYWNEWXZxMmJkK1EvWHNSWk5xcDFjPQ==;MjU5ODc1NEAzMjMyMmUzMDJlMzBhUlc4UkJLTzdwWU45NC8zR1pzWkpFNS80Qkd2S01CTkJkbjdFMUpCY3l3PQ==");
var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseBlazorFrameworkFiles();
app.UseStaticFiles();
app.UseRouting();

// app.UseCors();


if (app.Environment.IsDevelopment())
{
    app.UseCors(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
}
else
{
    app.UseCors(builder =>
    {
        builder.WithOrigins("https://trustedwebsite.com") //  trusted origin
            .WithMethods("GET", "POST") // needed methods
            .WithHeaders("Authorization"); //  needed headers
    });
}


app.MapRazorPages();
app.MapControllers();

app.MapHub<BlazorServerSignalrHub>("/blazorHub"); //  hub route

app.MapFallbackToFile("index.html");
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("MjU5ODc1M0AzMjMyMmUzMDJlMzBvQURpQWlkdVV1QXVtVnd4VW5hTm9WYWNEWXZxMmJkK1EvWHNSWk5xcDFjPQ==;MjU5ODc1NEAzMjMyMmUzMDJlMzBhUlc4UkJLTzdwWU45NC8zR1pzWkpFNS80Qkd2S01CTkJkbjdFMUpCY3l3PQ==");
app.Run();