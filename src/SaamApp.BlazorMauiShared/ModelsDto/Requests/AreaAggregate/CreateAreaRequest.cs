using System;

namespace SaamApp.BlazorMauiShared.Models.Area
{
    public class CreateAreaRequest : BaseRequest
    {
        public string AreaName { get; set; }
        public string AreaDescription { get; set; }
        public string AreaColor { get; set; }
        public string AreaImage { get; set; }
        public bool AreaStage { get; set; }
        public DateTime CreatedAt { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public Guid? UpdatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid TenantId { get; set; }
    }
}