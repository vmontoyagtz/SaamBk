using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Faq
{
    public class UpdateFaqRequest : BaseRequest
    {
        public Guid FaqId { get; set; }
        public string FaqQuestion { get; set; }
        public string FaqAnswer { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateFaqRequest FromDto(FaqDto faqDto)
        {
            return new UpdateFaqRequest
            {
                FaqId = faqDto.FaqId,
                FaqQuestion = faqDto.FaqQuestion,
                FaqAnswer = faqDto.FaqAnswer,
                TenantId = faqDto.TenantId
            };
        }
    }
}