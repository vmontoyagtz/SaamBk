using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class ListBusinessUnitAddressResponse : BaseResponse
    {
        public ListBusinessUnitAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListBusinessUnitAddressResponse()
        {
        }

        public List<BusinessUnitAddressDto> BusinessUnitAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}