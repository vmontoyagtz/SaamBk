using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorPhoneNumber
{
    public class UpdateAdvisorPhoneNumberRequest : BaseRequest
    {
        public int RowId { get; set; }
        public Guid AdvisorId { get; set; }
        public Guid PhoneNumberId { get; set; }
        public Guid PhoneNumberTypeId { get; set; }

        public static UpdateAdvisorPhoneNumberRequest FromDto(AdvisorPhoneNumberDto advisorPhoneNumberDto)
        {
            return new UpdateAdvisorPhoneNumberRequest
            {
                RowId = advisorPhoneNumberDto.RowId,
                AdvisorId = advisorPhoneNumberDto.AdvisorId,
                PhoneNumberId = advisorPhoneNumberDto.PhoneNumberId,
                PhoneNumberTypeId = advisorPhoneNumberDto.PhoneNumberTypeId
            };
        }
    }
}