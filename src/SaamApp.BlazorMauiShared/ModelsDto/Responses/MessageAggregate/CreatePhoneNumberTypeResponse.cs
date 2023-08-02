using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class CreatePhoneNumberTypeResponse : BaseResponse
    {
        public CreatePhoneNumberTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreatePhoneNumberTypeResponse()
        {
        }

        public PhoneNumberTypeDto PhoneNumberType { get; set; } = new();
    }
}