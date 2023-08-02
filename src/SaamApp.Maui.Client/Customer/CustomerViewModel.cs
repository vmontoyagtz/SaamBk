using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.AspNetCore.SignalR.Client;
using SaamApp.Domain.ModelsDto;
using SaamApp.Maui.Client.Common;

namespace SaamApp.Maui.Client.Customer
{
    public class CustomerViewModel : ViewModelBase, IDisposable
    {
        private readonly ICustomerService _customerService;
   
        private CustomerDto _currentCustomer;
        private BlazorServerSignalRService _blazorServerSignalRService;
        private ObservableCollection<CustomerDto> _customerCollection;
        private string _customerFirstName;
        private string _customerLastName;
        private int _pageIndex = 0;
        public ICommand DeleteCommand { get; }
        public ICommand SaveCommand { get; }
        public ICommand SendMessageCommand { get; }
      
        public CustomerViewModel(ICustomerService customerService,  BlazorServerSignalRService blazorServerSignalRService)
        {
            _blazorServerSignalRService = blazorServerSignalRService;
            _customerService = customerService;
         
            LoadCustomersCommand = new Command(async () => await LoadCustomersAsync());
            RefreshCommand = new Command(async () => await RefreshAsync());
            SaveCommand = new Command(async () => await SaveCustomerAsync(), () => !IsBusy && GetIsValid());
            DeleteCommand = new Command(async () => await DeleteCustomerAsync(CurrentCustomer.CustomerId));
            PropertyChanged += (s, e) =>
            {
                if ((e.PropertyName == nameof(CustomerFirstName) || e.PropertyName == nameof(CustomerLastName)) && e.PropertyName != nameof(IsBusy) && e.PropertyName != nameof(CurrentCustomer))
                {
                    SaveCommand.Execute(null);
                }
            };
             //  LoadDesignTimeData();

         
            SendMessageCommand = new Command(async () => await SendMessageAsync());
            _blazorServerSignalRService.MessageReceived += OnMessageReceived;
            Task.Run(LoadCustomersAsync);
        }

        private string _receivedMessage;
        public string ReceivedMessage
        {
            get => _receivedMessage;
            set
            {
                if (_receivedMessage != value)
                {
                    _receivedMessage = value;
                    OnPropertyChanged(nameof(ReceivedMessage));
                }
            }
        }

        private void OnMessageReceived(string message)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                ReceivedMessage = message;
            });
        }

        private async Task SendMessageAsync()
        {
            if (_blazorServerSignalRService.ConnectionState == HubConnectionState.Connected)
            {
                await _blazorServerSignalRService.FromClientSendMessageToOthersConnectedToBlazorServerAsync("Hello From Maui");
            }
        }

        public ObservableCollection<CustomerDto> CustomerCollection
        {
            get => _customerCollection;
            set => SetProperty(ref _customerCollection, value);
        }

        public CustomerDto CurrentCustomer
        {
            get => _currentCustomer;
            set
            {
                if (SetProperty(ref _currentCustomer, value))
                {
                    OnPropertyChanged(nameof(IsValid));
                }
            }
        }

        public ICommand LoadCustomersCommand { get; }
        public ICommand RefreshCommand { get; }
        public ObservableCollection<CustomerDto> Customers { get; set; }

        public string CustomerFirstName
        {
            get => _customerFirstName;
            set
            {
                if (SetProperty(ref _customerFirstName, value))
                {
                    ValidateProperty(value, nameof(CustomerFirstName));
                    ValidateFirstNameAndLastName();
                    OnPropertyChanged(nameof(GetIsValid));
                }
            }
        }

        public string CustomerLastName
        {
            get => _customerLastName;
            set
            {
                if (SetProperty(ref _customerLastName, value))
                {
                    ValidateProperty(value, nameof(CustomerLastName));
                    ValidateFirstNameAndLastName();
                    OnPropertyChanged(nameof(GetIsValid));
                }
            }
        }

        private void LoadDesignTimeData()
        {
            var designTimeCustomer = new DesignTimeCustomer();
            Customers = new ObservableCollection<CustomerDto>(designTimeCustomer);
            CurrentCustomer = Customers[0];
        }

        public override bool GetIsValid()
        {
            return !string.IsNullOrEmpty(CustomerFirstName) && !string.IsNullOrEmpty(CustomerLastName);
        }

        private async Task SaveCustomerAsync()
        {
            if (IsBusy)
            {
                return;
            }

            IsBusy = true;
            try
            {
                await _customerService.UpdateCustomerAsync(CurrentCustomer);
            }
            catch (Exception ex)
            {
                ErrorMessage = $"An error occurred while saving the customer: {ex.Message}";
            }
            finally
            {
                IsBusy = false;
            }
        }

        private void ValidateFirstNameAndLastName()
        {
            if (_customerFirstName == _customerLastName)
            {
                AddError(nameof(CustomerLastName), "First name and last name cannot be the same");
            }
            else
            {
                RemoveError(nameof(CustomerLastName), "First name and last name cannot be the same");
            }
        }

        private async Task RefreshAsync()
        {
            IsBusy = true;
            CustomerCollection.Clear();
            await LoadCustomersAsync();
            IsBusy = false;
        }

        private async Task LoadCustomersAsync()
        {
            IsBusy = true;
            try
            {
                var response = await _customerService.GetCustomersAsync(_pageIndex);
                var customers = response.Customers;
                CustomerCollection = new ObservableCollection<CustomerDto>(customers);
                CurrentCustomer = customers[0];
             
            }
            catch (Exception ex)
            {
                ErrorMessage = "An error occurred while loading customers: " + ex.Message;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task LoadCustomerAsync(Guid customerId)
        {
            IsBusy = true;
            try
            {
                var response = await _customerService.GetCustomerAsync(customerId);
                CurrentCustomer = response.Customer;
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task UpdateCustomerAsync()
        {
            IsBusy = true;
            try
            {
                await _customerService.UpdateCustomerAsync(CurrentCustomer);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            IsBusy = true;
            try
            {
                await _customerService.DeleteCustomerAsync(customerId);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public async Task CreateCustomerAsync(CustomerDto newCustomer)
        {
            IsBusy = true;
            try
            {
                await _customerService.CreateCustomerAsync(newCustomer);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void Dispose()
        {
            _blazorServerSignalRService.MessageReceived -= OnMessageReceived;
        }
    }
}