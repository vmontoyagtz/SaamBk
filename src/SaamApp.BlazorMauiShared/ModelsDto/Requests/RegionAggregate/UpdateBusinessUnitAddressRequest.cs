using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitAddress
{
    public class UpdateBusinessUnitAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AddressId { get; set; }
        public Guid AddressTypeId { get; set; }
        public Guid BusinessUnitId { get; set; }

        public static UpdateBusinessUnitAddressRequest FromDto(BusinessUnitAddressDto businessUnitAddressDto)
        {
            return new UpdateBusinessUnitAddressRequest
            {
                RowId = businessUnitAddressDto.RowId,
                AddressId = businessUnitAddressDto.AddressId,
                AddressTypeId = businessUnitAddressDto.AddressTypeId,
                BusinessUnitId = businessUnitAddressDto.BusinessUnitId
            };
        }
    }
}