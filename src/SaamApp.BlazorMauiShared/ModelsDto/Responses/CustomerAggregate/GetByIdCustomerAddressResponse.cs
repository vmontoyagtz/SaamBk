using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerAddress
{
    public class GetByIdCustomerAddressResponse : BaseResponse
    {
        public GetByIdCustomerAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerAddressResponse()
        {
        }

        public CustomerAddressDto CustomerAddress { get; set; } = new();
    }
}