using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class CreateBusinessUnitAddressResponse : BaseResponse
    {
        public CreateBusinessUnitAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBusinessUnitAddressResponse()
        {
        }

        public BusinessUnitAddressDto BusinessUnitAddress { get; set; } = new();
    }
}