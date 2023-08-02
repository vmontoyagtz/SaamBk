using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class UpdateBusinessUnitTypeResponse : BaseResponse
    {
        public UpdateBusinessUnitTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBusinessUnitTypeResponse()
        {
        }

        public BusinessUnitTypeDto BusinessUnitType { get; set; } = new();
    }
}