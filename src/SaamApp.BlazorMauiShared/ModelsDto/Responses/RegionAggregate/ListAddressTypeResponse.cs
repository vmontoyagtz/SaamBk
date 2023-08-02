using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AddressType
{
    public class ListAddressTypeResponse : BaseResponse
    {
        public ListAddressTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAddressTypeResponse()
        {
        }

        public List<AddressTypeDto> AddressTypes { get; set; } = new();

        public int Count { get; set; }
    }
}