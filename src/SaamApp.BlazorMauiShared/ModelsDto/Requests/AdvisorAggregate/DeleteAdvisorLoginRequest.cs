using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class DeleteAdvisorLoginRequest : BaseRequest
    {
        public Guid AdvisorLoginId { get; set; }
    }
}