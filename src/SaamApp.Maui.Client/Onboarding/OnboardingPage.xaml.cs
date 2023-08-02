using SaamApp.Maui.Client.Welcome;
namespace SaamApp.Maui.Client.Onboarding;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();
        BindingContext = new OnboardingViewModel();
    }

    private async void NavigateToWelcomePage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WelcomePage());
    }

}
