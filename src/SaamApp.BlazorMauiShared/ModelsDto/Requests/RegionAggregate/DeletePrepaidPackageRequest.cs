using System;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class DeletePrepaidPackageRequest : BaseRequest
    {
        public Guid PrepaidPackageId { get; set; }
    }
}