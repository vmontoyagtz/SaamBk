using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class UpdateBusinessUnitAddressResponse : BaseResponse
    {
        public UpdateBusinessUnitAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBusinessUnitAddressResponse()
        {
        }

        public BusinessUnitAddressDto BusinessUnitAddress { get; set; } = new();
    }
}