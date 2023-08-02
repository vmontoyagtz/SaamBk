using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitDocument
{
    public class DeleteBusinessUnitDocumentResponse : BaseResponse
    {
        public DeleteBusinessUnitDocumentResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteBusinessUnitDocumentResponse()
        {
        }
    }
}