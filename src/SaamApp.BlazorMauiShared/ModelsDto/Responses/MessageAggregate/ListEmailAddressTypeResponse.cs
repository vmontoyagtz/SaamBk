using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class ListEmailAddressTypeResponse : BaseResponse
    {
        public ListEmailAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListEmailAddressTypeResponse()
        {
        }

        public List<EmailAddressTypeDto> EmailAddressTypes { get; set; } = new();

        public int Count { get; set; }
    }
}