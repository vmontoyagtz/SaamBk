using System;

namespace SaamApp.BlazorMauiShared.Models.AdvisorBankTransferInfo
{
    public class DeleteAdvisorBankTransferInfoResponse : BaseResponse
    {
        public DeleteAdvisorBankTransferInfoResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteAdvisorBankTransferInfoResponse()
        {
        }
    }
}