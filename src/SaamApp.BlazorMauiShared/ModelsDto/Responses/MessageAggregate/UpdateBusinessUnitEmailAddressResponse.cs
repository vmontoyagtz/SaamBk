using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class UpdateBusinessUnitEmailAddressResponse : BaseResponse
    {
        public UpdateBusinessUnitEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBusinessUnitEmailAddressResponse()
        {
        }

        public BusinessUnitEmailAddressDto BusinessUnitEmailAddress { get; set; } = new();
    }
}