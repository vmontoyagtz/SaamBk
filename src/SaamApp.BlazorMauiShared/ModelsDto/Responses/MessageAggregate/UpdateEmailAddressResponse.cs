using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class UpdateEmailAddressResponse : BaseResponse
    {
        public UpdateEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateEmailAddressResponse()
        {
        }

        public EmailAddressDto EmailAddress { get; set; } = new();
    }
}