using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Maui.Client.Customer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerApi _apiService;

        public CustomerService(ICustomerApi apiService)
        {
            _apiService = apiService;
        }

        public async Task<GetByIdCustomerResponse> GetCustomerAsync(Guid customerId)
        {
            return await _apiService.GetOneCustomerAsync($"api/customers/i/{customerId}");
        }

        public async Task UpdateCustomerAsync(CustomerDto customer)
        {
            await _apiService.UpdateCustomerAsync($"api/customers", customer);
        }

        public async Task<ListCustomerResponse> GetCustomersAsync(int pageIndex)
        {
            var response = await _apiService.GetCustomerListAsync("api/customers");
            return response;
        }

        public async Task DeleteCustomerAsync(Guid customerId)
        {
            await _apiService.DeleteCustomerAsync($"api/customers/{customerId}");
        }

        public async Task CreateCustomerAsync(CustomerDto customer)
        {
            await _apiService.PostAsync<CustomerDto>("api/customers", customer);
        }
    }
}