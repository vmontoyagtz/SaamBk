using System;

namespace SaamApp.BlazorMauiShared.Models.CustomerDocument
{
    public class DeleteCustomerDocumentResponse : BaseResponse
    {
        public DeleteCustomerDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteCustomerDocumentResponse()
        {
        }
    }
}