using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class DeletePrepaidPackageResponse : BaseResponse
    {
        public DeletePrepaidPackageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public DeletePrepaidPackageResponse()
        {
        }
    }
}