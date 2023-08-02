using System;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class DeleteFaqRequest : BaseRequest
    {
        public Guid FaqId { get; set; }
    }
}