using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class ListAdvisorPhoneNumberResponse : BaseResponse
    {
        public ListAdvisorPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorPhoneNumberResponse()
        {
        }

        public List<AdvisorPhoneNumberDto> AdvisorPhoneNumbers { get; set; } = new();

        public int Count { get; set; }
    }
}