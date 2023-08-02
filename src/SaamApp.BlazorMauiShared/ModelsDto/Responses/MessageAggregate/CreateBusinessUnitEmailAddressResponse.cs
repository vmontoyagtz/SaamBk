using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class CreateBusinessUnitEmailAddressResponse : BaseResponse
    {
        public CreateBusinessUnitEmailAddressResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBusinessUnitEmailAddressResponse()
        {
        }

        public BusinessUnitEmailAddressDto BusinessUnitEmailAddress { get; set; } = new();
    }
}