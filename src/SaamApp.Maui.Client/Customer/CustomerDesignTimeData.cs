using System.Collections.ObjectModel;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Maui.Client.Customer
{
    public class DesignTimeCustomer : ObservableCollection<CustomerDto>
    {
        public DesignTimeCustomer()
        {
            for (var i = 0; i < 10; i++)
            {
                Add(CreateDesignCustomer(i));
            }
        }

        public CustomerDto CreateDesignCustomer(int i)
        {
            var customer = new CustomerDto()
            {
                CustomerId = Guid.NewGuid(),
                CustomerFirstName = "Oscar",
                CustomerLastName = "Agreda",
                CustomerProfileThumbnailPath = "Customer Profile Thumbnail Path",
                CustomerBirthDate = Convert.ToDateTime("12/12/2012"),
                CreatedAt = Convert.ToDateTime("12/12/2012"),
                CreatedBy = Guid.NewGuid(),
                UpdatedAt = Convert.ToDateTime("12/12/2012"),
                UpdatedBy = Guid.NewGuid(),
                IsDeleted = true,
                TenantId = Guid.NewGuid(),
                GenderId = Guid.NewGuid()
            };
            return customer;
        }
    }
}