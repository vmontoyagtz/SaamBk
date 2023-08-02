using System.Diagnostics;
using SaamApp.Maui.Client.Common;
using Syncfusion.Licensing;
using SaamApp.Maui.Client.Onboarding;
namespace SaamApp.Maui.Client
{
    public partial class App : Application
    {
        private readonly BlazorServerSignalRService _blazorServerSignalRService;
        public App(BlazorServerSignalRService blazorServerSignalRService)
        {
            _blazorServerSignalRService = blazorServerSignalRService;
            //Register Syncfusion license
            SyncfusionLicenseProvider.RegisterLicense("MjU5ODc1M0AzMjMyMmUzMDJlMzBvQURpQWlkdVV1QXVtVnd4VW5hTm9WYWNEWXZxMmJkK1EvWHNSWk5xcDFjPQ==;MjU5ODc1NEAzMjMyMmUzMDJlMzBhUlc4UkJLTzdwWU45NC8zR1pzWkpFNS80Qkd2S01CTkJkbjdFMUpCY3l3PQ==");
            InitializeComponent();
       
            MainPage = new AppShell();
        }
        private void HandleReceivedMessage()
        {
            Debug.WriteLine("maui HandleReceivedMessage");
         

        }

        /*protected override void OnStart()
        {
            MainPage = new NavigationPage(new OnboardingPage());
        }*/

        protected override void OnSleep()
        {
            Debug.WriteLine("maui OnSleep");
            Task.Run(() => _blazorServerSignalRService.DisconnectAsync());
        }

        protected override void OnResume()
        {
            Debug.WriteLine("maui OnResume");
            Task.Run(() => _blazorServerSignalRService.ConnectAsync());
          
        }
    }
}