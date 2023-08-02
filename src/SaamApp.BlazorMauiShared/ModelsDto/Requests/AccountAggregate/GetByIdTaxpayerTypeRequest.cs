using System;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class GetByIdTaxpayerTypeRequest : BaseRequest
    {
        public Guid TaxpayerTypeId { get; set; }
    }
}