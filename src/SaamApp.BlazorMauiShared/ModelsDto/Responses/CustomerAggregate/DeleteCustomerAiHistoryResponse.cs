using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerAiHistory
{
    public class DeleteCustomerAiHistoryResponse : BaseResponse
    {
        public DeleteCustomerAiHistoryResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerAiHistoryResponse()
        {
        }
    }
}