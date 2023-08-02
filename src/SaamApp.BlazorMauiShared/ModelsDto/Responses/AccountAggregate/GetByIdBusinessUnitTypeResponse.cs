using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitType
{
    public class GetByIdBusinessUnitTypeResponse : BaseResponse
    {
        public GetByIdBusinessUnitTypeResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBusinessUnitTypeResponse()
        {
        }

        public BusinessUnitTypeDto BusinessUnitType { get; set; } = new();
    }
}