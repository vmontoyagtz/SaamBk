using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class GetByIdBusinessUnitAddressResponse : BaseResponse
    {
        public GetByIdBusinessUnitAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBusinessUnitAddressResponse()
        {
        }

        public BusinessUnitAddressDto BusinessUnitAddress { get; set; } = new();
    }
}