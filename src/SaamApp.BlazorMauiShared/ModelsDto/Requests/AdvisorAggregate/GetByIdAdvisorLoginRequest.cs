using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class GetByIdAdvisorLoginRequest : BaseRequest
    {
        public Guid AdvisorLoginId { get; set; }
    }
}