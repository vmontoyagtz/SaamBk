using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBank
{
    public class DeleteAdvisorBankResponse : BaseResponse
    {
        public DeleteAdvisorBankResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorBankResponse()
        {
        }
    }
}