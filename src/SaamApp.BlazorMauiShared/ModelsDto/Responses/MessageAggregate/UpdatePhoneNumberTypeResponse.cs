using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class UpdatePhoneNumberTypeResponse : BaseResponse
    {
        public UpdatePhoneNumberTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdatePhoneNumberTypeResponse()
        {
        }

        public PhoneNumberTypeDto PhoneNumberType { get; set; } = new();
    }
}