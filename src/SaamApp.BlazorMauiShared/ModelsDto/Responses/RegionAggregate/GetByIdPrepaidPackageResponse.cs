using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class GetByIdPrepaidPackageResponse : BaseResponse
    {
        public GetByIdPrepaidPackageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdPrepaidPackageResponse()
        {
        }

        public PrepaidPackageDto PrepaidPackage { get; set; } = new();
    }
}