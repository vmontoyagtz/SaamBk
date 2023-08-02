using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class ListAdvisorAddressResponse : BaseResponse
    {
        public ListAdvisorAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorAddressResponse()
        {
        }

        public List<AdvisorAddressDto> AdvisorAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}