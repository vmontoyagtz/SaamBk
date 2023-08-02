using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class UpdateCustomerEmailAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid CustomerId { get; set; }
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }

        public static UpdateCustomerEmailAddressRequest FromDto(CustomerEmailAddressDto customerEmailAddressDto)
        {
            return new UpdateCustomerEmailAddressRequest
            {
                RowId = customerEmailAddressDto.RowId,
                CustomerId = customerEmailAddressDto.CustomerId,
                EmailAddressId = customerEmailAddressDto.EmailAddressId,
                EmailAddressTypeId = customerEmailAddressDto.EmailAddressTypeId
            };
        }
    }
}