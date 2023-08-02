using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class ListBusinessUnitPhoneNumberResponse : BaseResponse
    {
        public ListBusinessUnitPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBusinessUnitPhoneNumberResponse()
        {
        }

        public List<BusinessUnitPhoneNumberDto> BusinessUnitPhoneNumbers { get; set; } = new();

        public int Count { get; set; }
    }
}