using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Maui.Client.Customer
{
    public interface ICustomerApi : IDisposable
    {
        Task<GetByIdCustomerResponse> GetOneCustomerAsync(string uri);

        Task<ListCustomerResponse> GetCustomerListAsync(string uri);

        Task PostAsync<T>(string uri, T data);

        Task UpdateCustomerAsync(string uri, CustomerDto data);

        Task DeleteCustomerAsync(string uri);
    }
}