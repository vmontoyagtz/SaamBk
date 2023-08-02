using System;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class GetByIdFaqRequest : BaseRequest
    {
        public Guid FaqId { get; set; }
    }
}