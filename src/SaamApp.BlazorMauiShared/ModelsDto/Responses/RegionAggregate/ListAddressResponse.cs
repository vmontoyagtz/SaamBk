using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Address
{
    public class ListAddressResponse : BaseResponse
    {
        public ListAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAddressResponse()
        {
        }

        public List<AddressDto> Addresses { get; set; } = new();

        public int Count { get; set; }
    }
}