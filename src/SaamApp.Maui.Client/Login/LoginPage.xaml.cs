using SaamApp.Maui.Client.Welcome;
namespace SaamApp.Maui.Client.Login;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void ToLastPage(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new WelcomePage());
    }

}
