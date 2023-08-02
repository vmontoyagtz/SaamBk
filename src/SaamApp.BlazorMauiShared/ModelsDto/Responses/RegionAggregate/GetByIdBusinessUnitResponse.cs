using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class GetByIdBusinessUnitResponse : BaseResponse
    {
        public GetByIdBusinessUnitResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdBusinessUnitResponse()
        {
        }

        public BusinessUnitDto BusinessUnit { get; set; } = new();
    }
}