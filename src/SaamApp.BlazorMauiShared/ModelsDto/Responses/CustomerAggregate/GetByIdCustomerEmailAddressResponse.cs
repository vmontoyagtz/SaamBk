using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerEmailAddress
{
    public class GetByIdCustomerEmailAddressResponse : BaseResponse
    {
        public GetByIdCustomerEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerEmailAddressResponse()
        {
        }

        public CustomerEmailAddressDto CustomerEmailAddress { get; set; } = new();
    }
}