using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class UpdateEmailAddressTypeResponse : BaseResponse
    {
        public UpdateEmailAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateEmailAddressTypeResponse()
        {
        }

        public EmailAddressTypeDto EmailAddressType { get; set; } = new();
    }
}