using System;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class DeleteTaxpayerTypeResponse : BaseResponse
    {
        public DeleteTaxpayerTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeleteTaxpayerTypeResponse()
        {
        }
    }
}