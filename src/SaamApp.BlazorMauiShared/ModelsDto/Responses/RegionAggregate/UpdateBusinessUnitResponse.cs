using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class UpdateBusinessUnitResponse : BaseResponse
    {
        public UpdateBusinessUnitResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateBusinessUnitResponse()
        {
        }

        public BusinessUnitDto BusinessUnit { get; set; } = new();
    }
}