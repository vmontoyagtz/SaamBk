using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class CreatePhoneNumberResponse : BaseResponse
    {
        public CreatePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreatePhoneNumberResponse()
        {
        }

        public PhoneNumberDto PhoneNumber { get; set; } = new();
    }
}