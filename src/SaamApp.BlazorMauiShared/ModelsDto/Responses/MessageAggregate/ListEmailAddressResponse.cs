using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class ListEmailAddressResponse : BaseResponse
    {
        public ListEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListEmailAddressResponse()
        {
        }

        public List<EmailAddressDto> EmailAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}