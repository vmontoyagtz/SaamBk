using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class CreateBusinessUnitPhoneNumberResponse : BaseResponse
    {
        public CreateBusinessUnitPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBusinessUnitPhoneNumberResponse()
        {
        }

        public BusinessUnitPhoneNumberDto BusinessUnitPhoneNumber { get; set; } = new();
    }
}