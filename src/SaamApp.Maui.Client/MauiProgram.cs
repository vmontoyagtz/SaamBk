using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Logging;
using SaamApp.Maui.Client.Common;
using SaamApp.Maui.Client.Customer;
using Syncfusion.Maui.Core.Hosting;

namespace SaamApp.Maui.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureSyncfusionCore()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("MonserratRegular.ttf", "MontserratRegular");
                    fonts.AddFont("MontserratBlack.ttf", "MontserratBlack");
                    fonts.AddFont("FaBrands400.ttf", "FaBrands");
                    fonts.AddFont("FaRegular400.ttf", "FaRegular");
                    fonts.AddFont("FaSolid900.ttf", "FaSolid");
                    fonts.AddFont("icomoon.ttf", "Icomoon");
                });

#if DEBUG
            builder.Logging.AddDebug();
#endif

            var services = builder.Services;

            builder.Services.AddSingleton<BlazorServerSignalRService>();
            builder.Services.AddSingleton<SaamApiSignalRService>();

            services.AddSingleton<CustomerEditPage>();

            services.AddSingleton<ICustomerApi, CustomerApi>();
            services.AddSingleton<ICustomerService, CustomerService>();



            // Ensure BlazorServerSignalRService is created before CustomerViewModel
            var blazorServerSignalRService = services.BuildServiceProvider().GetService<BlazorServerSignalRService>();
            services.AddSingleton<CustomerViewModel>(new CustomerViewModel(services.BuildServiceProvider().GetService<ICustomerService>(), blazorServerSignalRService));







            return builder.Build();
        }
    }
}