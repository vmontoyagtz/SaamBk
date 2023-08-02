using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class UpdatePrepaidPackageResponse : BaseResponse
    {
        public UpdatePrepaidPackageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdatePrepaidPackageResponse()
        {
        }

        public PrepaidPackageDto PrepaidPackage { get; set; } = new();
    }
}