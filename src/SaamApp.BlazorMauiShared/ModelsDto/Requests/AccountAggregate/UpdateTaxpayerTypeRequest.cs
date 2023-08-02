using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.TaxpayerType
{
    public class UpdateTaxpayerTypeRequest : BaseRequest
    {
        public Guid TaxpayerTypeId { get; set; }
        public string TaxpayerTypeName { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateTaxpayerTypeRequest FromDto(TaxpayerTypeDto taxpayerTypeDto)
        {
            return new UpdateTaxpayerTypeRequest
            {
                TaxpayerTypeId = taxpayerTypeDto.TaxpayerTypeId,
                TaxpayerTypeName = taxpayerTypeDto.TaxpayerTypeName,
                TenantId = taxpayerTypeDto.TenantId
            };
        }
    }
}