using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class ListPhoneNumberResponse : BaseResponse
    {
        public ListPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListPhoneNumberResponse()
        {
        }

        public List<PhoneNumberDto> PhoneNumbers { get; set; } = new();

        public int Count { get; set; }
    }
}