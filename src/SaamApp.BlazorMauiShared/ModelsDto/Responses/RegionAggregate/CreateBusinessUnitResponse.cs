using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class CreateBusinessUnitResponse : BaseResponse
    {
        public CreateBusinessUnitResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateBusinessUnitResponse()
        {
        }

        public BusinessUnitDto BusinessUnit { get; set; } = new();
    }
}