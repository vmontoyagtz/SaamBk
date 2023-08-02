using System;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class GetByIdAdvisorRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
    }
}