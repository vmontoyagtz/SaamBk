using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class ListAdvisorEmailAddressResponse : BaseResponse
    {
        public ListAdvisorEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorEmailAddressResponse()
        {
        }

        public List<AdvisorEmailAddressDto> AdvisorEmailAddresses { get; set; } = new();

        public int Count { get; set; }
    }
}