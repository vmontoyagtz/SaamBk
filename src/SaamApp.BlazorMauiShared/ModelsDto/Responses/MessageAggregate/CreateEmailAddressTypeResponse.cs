using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class CreateEmailAddressTypeResponse : BaseResponse
    {
        public CreateEmailAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateEmailAddressTypeResponse()
        {
        }

        public EmailAddressTypeDto EmailAddressType { get; set; } = new();
    }
}