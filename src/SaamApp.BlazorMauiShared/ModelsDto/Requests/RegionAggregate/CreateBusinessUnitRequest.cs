using System;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class CreateBusinessUnitRequest : BaseRequest
    {
        public string BusinessUnitName { get; set; }
        public Guid BusinessAddressId { get; set; }
        public Guid BusinessPhoneNumberId { get; set; }
        public Guid BusinessEmailAddressId { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}