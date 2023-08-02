using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class GetByIdBusinessUnitPhoneNumberResponse : BaseResponse
    {
        public GetByIdBusinessUnitPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBusinessUnitPhoneNumberResponse()
        {
        }

        public BusinessUnitPhoneNumberDto BusinessUnitPhoneNumber { get; set; } = new();
    }
}