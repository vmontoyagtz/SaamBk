using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class UpdatePhoneNumberResponse : BaseResponse
    {
        public UpdatePhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdatePhoneNumberResponse()
        {
        }

        public PhoneNumberDto PhoneNumber { get; set; } = new();
    }
}