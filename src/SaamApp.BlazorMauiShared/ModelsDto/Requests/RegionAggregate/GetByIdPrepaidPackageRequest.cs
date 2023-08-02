using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class GetByIdPrepaidPackageRequest : BaseRequest
    {
        public Guid PrepaidPackageId { get; set; }
    }
}