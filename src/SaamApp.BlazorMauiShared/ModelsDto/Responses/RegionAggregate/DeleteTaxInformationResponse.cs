using System;

namespace SaamApp.BlazorMauiShared.Models.TaxInformation
{
    public class DeleteTaxInformationResponse : BaseResponse
    {
        public DeleteTaxInformationResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTaxInformationResponse()
        {
        }
    }
}