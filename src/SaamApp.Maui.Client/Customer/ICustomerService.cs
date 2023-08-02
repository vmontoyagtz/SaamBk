using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Maui.Client.Customer
{
    public interface ICustomerService
    {
        Task<GetByIdCustomerResponse> GetCustomerAsync(Guid customerId);

        Task UpdateCustomerAsync(CustomerDto customer);

        Task<ListCustomerResponse> GetCustomersAsync(int pageIndex);

        Task DeleteCustomerAsync(Guid customerId);

        Task CreateCustomerAsync(CustomerDto customer);
    }
}