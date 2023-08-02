using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class GetByIdPhoneNumberResponse : BaseResponse
    {
        public GetByIdPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdPhoneNumberResponse()
        {
        }

        public PhoneNumberDto PhoneNumber { get; set; } = new();
    }
}