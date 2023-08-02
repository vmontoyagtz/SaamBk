using System;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class CreateFaqRequest : BaseRequest
    {
        public string FaqQuestion { get; set; }
        public string FaqAnswer { get; set; }
        public Guid TenantId { get; set; }
    }
}