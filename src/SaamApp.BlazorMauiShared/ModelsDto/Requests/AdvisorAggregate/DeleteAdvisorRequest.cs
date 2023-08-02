using System;

namespace SaamApp.BlazorMauiShared.Models.Advisor
{
    public class DeleteAdvisorRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
    }
}