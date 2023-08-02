using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumberType
{
    public class ListPhoneNumberTypeResponse : BaseResponse
    {
        public ListPhoneNumberTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListPhoneNumberTypeResponse()
        {
        }

        public List<PhoneNumberTypeDto> PhoneNumberTypes { get; set; } = new();

        public int Count { get; set; }
    }
}