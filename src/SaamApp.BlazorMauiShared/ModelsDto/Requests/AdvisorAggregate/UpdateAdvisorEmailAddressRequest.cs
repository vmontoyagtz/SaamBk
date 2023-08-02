using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorEmailAddress
{
    public class UpdateAdvisorEmailAddressRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid EmailAddressId { get; set; }
        public Guid EmailAddressTypeId { get; set; }

        public static UpdateAdvisorEmailAddressRequest FromDto(AdvisorEmailAddressDto advisorEmailAddressDto)
        {
            return new UpdateAdvisorEmailAddressRequest
            {
                RowId = advisorEmailAddressDto.RowId,
                AdvisorId = advisorEmailAddressDto.AdvisorId,
                EmailAddressId = advisorEmailAddressDto.EmailAddressId,
                EmailAddressTypeId = advisorEmailAddressDto.EmailAddressTypeId
            };
        }
    }
}