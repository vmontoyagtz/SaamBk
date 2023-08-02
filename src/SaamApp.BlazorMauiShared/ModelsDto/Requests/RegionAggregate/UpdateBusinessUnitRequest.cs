using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnit
{
    public class UpdateBusinessUnitRequest : BaseRequest
    {
        public Guid BusinessUnitId { get; set; }
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

        public static UpdateBusinessUnitRequest FromDto(BusinessUnitDto businessUnitDto)
        {
            return new UpdateBusinessUnitRequest
            {
                BusinessUnitId = businessUnitDto.BusinessUnitId,
                BusinessUnitName = businessUnitDto.BusinessUnitName,
                BusinessAddressId = businessUnitDto.BusinessAddressId,
                BusinessPhoneNumberId = businessUnitDto.BusinessPhoneNumberId,
                BusinessEmailAddressId = businessUnitDto.BusinessEmailAddressId,
                CreatedAt = businessUnitDto.CreatedAt,
                CreatedBy = businessUnitDto.CreatedBy,
                UpdatedAt = businessUnitDto.UpdatedAt,
                UpdatedBy = businessUnitDto.UpdatedBy,
                IsDeleted = businessUnitDto.IsDeleted,
                TenantId = businessUnitDto.TenantId
            };
        }
    }
}