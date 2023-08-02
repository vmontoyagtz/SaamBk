using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class GetByIdBusinessUnitEmailAddressResponse : BaseResponse
    {
        public GetByIdBusinessUnitEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBusinessUnitEmailAddressResponse()
        {
        }

        public BusinessUnitEmailAddressDto BusinessUnitEmailAddress { get; set; } = new();
    }
}