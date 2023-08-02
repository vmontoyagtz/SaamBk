using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class ListAdvisorResponse : BaseResponse
    {
        public ListAdvisorResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAdvisorResponse()
        {
        }

        public List<AdvisorDto> Advisors { get; set; } = new();

        public int Count { get; set; }
    }
}