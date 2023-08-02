using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitPhoneNumber
{
    public class UpdateBusinessUnitPhoneNumberResponse : BaseResponse
    {
        public UpdateBusinessUnitPhoneNumberResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBusinessUnitPhoneNumberResponse()
        {
        }

        public BusinessUnitPhoneNumberDto BusinessUnitPhoneNumber { get; set; } = new();
    }
}