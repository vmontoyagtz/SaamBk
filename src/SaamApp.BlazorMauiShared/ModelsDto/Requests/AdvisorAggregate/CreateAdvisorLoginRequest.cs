using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class CreateAdvisorLoginRequest : BaseRequest
    {
        public Guid AdvisorId { get; set; }
        public DateTime AdvisorLoginDateTime { get; set; }
        public bool AdvisorLoginStage { get; set; }
    }
}