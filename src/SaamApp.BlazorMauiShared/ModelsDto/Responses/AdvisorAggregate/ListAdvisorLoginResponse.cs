using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class ListAdvisorLoginResponse : BaseResponse
    {
        public ListAdvisorLoginResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorLoginResponse()
        {
        }

        public List<AdvisorLoginDto> AdvisorLogins { get; set; } = new();

        public int Count { get; set; }
    }
}