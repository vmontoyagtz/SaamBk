using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class GetByIdPhoneNumberTypeResponse : BaseResponse
    {
        public GetByIdPhoneNumberTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdPhoneNumberTypeResponse()
        {
        }

        public PhoneNumberTypeDto PhoneNumberType { get; set; } = new();
    }
}