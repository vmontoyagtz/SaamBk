namespace SaamApp.Maui.Client.Customer
{
    public partial class CustomerEditPage : ContentPage
    {
        public CustomerEditPage(CustomerViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;
        }
    }
}