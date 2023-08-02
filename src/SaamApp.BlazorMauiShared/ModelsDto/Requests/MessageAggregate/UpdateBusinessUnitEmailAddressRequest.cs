using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress
{
    public class UpdateBusinessUnitEmailAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid BusinessUnitId { get; set; }
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }

        public static UpdateBusinessUnitEmailAddressRequest FromDto(
            BusinessUnitEmailAddressDto businessUnitEmailAddressDto)
        {
            return new UpdateBusinessUnitEmailAddressRequest
            {
                RowId = businessUnitEmailAddressDto.RowId,
                BusinessUnitId = businessUnitEmailAddressDto.BusinessUnitId,
                EmailAddressId = businessUnitEmailAddressDto.EmailAddressId,
                EmailAddressTypeId = businessUnitEmailAddressDto.EmailAddressTypeId
            };
        }
    }
}