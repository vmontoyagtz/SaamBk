using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class CreateBusinessUnitTypeResponse : BaseResponse
    {
        public CreateBusinessUnitTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBusinessUnitTypeResponse()
        {
        }

        public BusinessUnitTypeDto BusinessUnitType { get; set; } = new();
    }
}