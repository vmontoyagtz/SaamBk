using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Maui.Client.Customer
{
    public class CustomerApi : ICustomerApi, IDisposable
    {
        private readonly HttpClient _httpClient;

        public CustomerApi()
        {
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
            };
            var baseAddress = DeviceInfo.Platform == DevicePlatform.Android ? "https://10.0.2.2:5257/" : "https://localhost:5257/";
            _httpClient = new HttpClient(handler) { BaseAddress = new Uri(baseAddress) };

        }

        public async Task<GetByIdCustomerResponse> GetOneCustomerAsync(string uri)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<GetByIdCustomerResponse>(uri);
                if (response != null)
                {
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<ListCustomerResponse> GetCustomerListAsync(string uri)
        {
            try
            {
                var response = await _httpClient.GetFromJsonAsync<ListCustomerResponse>(uri);
                if (response != null && response.Customers.Any())
                {
                    return response;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task PostAsync<T>(string uri, T data)
        {
            var content = new StringContent(JsonSerializer.Serialize(data), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
        }

        public async Task UpdateCustomerAsync(string uri, CustomerDto data)
        {
            var  response = await _httpClient.PutAsJsonAsync(uri,data);
            response.EnsureSuccessStatusCode();
        }

        public async Task DeleteCustomerAsync(string uri)
        {
            var response = await _httpClient.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}