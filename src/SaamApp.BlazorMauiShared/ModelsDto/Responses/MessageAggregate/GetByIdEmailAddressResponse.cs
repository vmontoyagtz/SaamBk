using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class GetByIdEmailAddressResponse : BaseResponse
    {
        public GetByIdEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdEmailAddressResponse()
        {
        }

        public EmailAddressDto EmailAddress { get; set; } = new();
    }
}