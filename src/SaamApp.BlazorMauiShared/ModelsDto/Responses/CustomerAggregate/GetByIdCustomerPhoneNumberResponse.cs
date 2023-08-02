using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.CustomerPhoneNumber
{
    public class GetByIdCustomerPhoneNumberResponse : BaseResponse
    {
        public GetByIdCustomerPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdCustomerPhoneNumberResponse()
        {
        }

        public CustomerPhoneNumberDto CustomerPhoneNumber { get; set; } = new();
    }
}