using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAddress
{
    public class UpdateCustomerAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AddressId { get; set; }
        public Guid AddressTypeId { get; set; }
        public Guid CustomerId { get; set; }

        public static UpdateCustomerAddressRequest FromDto(CustomerAddressDto customerAddressDto)
        {
            return new UpdateCustomerAddressRequest
            {
                RowId = customerAddressDto.RowId,
                AddressId = customerAddressDto.AddressId,
                AddressTypeId = customerAddressDto.AddressTypeId,
                CustomerId = customerAddressDto.CustomerId
            };
        }
    }
}