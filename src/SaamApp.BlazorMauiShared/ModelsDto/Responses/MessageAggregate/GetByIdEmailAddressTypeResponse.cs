using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class GetByIdEmailAddressTypeResponse : BaseResponse
    {
        public GetByIdEmailAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdEmailAddressTypeResponse()
        {
        }

        public EmailAddressTypeDto EmailAddressType { get; set; } = new();
    }
}