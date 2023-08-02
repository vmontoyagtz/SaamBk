using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class ListBusinessUnitEmailAddressResponse : BaseResponse
    {
        public ListBusinessUnitEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBusinessUnitEmailAddressResponse()
        {
        }

        public List<BusinessUnitEmailAddressDto> BusinessUnitEmailAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}