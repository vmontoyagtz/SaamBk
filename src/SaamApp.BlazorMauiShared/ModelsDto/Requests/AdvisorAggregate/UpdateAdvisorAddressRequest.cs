using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorAddress
{
    public class UpdateAdvisorAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AddressId { get; set; }
        public Guid AddressTypeId { get; set; }
        public Guid AdvisorId { get; set; }

        public static UpdateAdvisorAddressRequest FromDto(AdvisorAddressDto advisorAddressDto)
        {
            return new UpdateAdvisorAddressRequest
            {
                RowId = advisorAddressDto.RowId,
                AddressId = advisorAddressDto.AddressId,
                AddressTypeId = advisorAddressDto.AddressTypeId,
                AdvisorId = advisorAddressDto.AdvisorId
            };
        }
    }
}