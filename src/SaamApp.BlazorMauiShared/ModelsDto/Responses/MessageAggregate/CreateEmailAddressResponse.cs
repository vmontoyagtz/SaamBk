using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class CreateEmailAddressResponse : BaseResponse
    {
        public CreateEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateEmailAddressResponse()
        {
        }

        public EmailAddressDto EmailAddress { get; set; } = new();
    }
}