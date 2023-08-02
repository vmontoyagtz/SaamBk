using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class CreatePrepaidPackageResponse : BaseResponse
    {
        public CreatePrepaidPackageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreatePrepaidPackageResponse()
        {
        }

        public PrepaidPackageDto PrepaidPackage { get; set; } = new();
    }
}