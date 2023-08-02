using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AdvisorLogin
{
    public class UpdateAdvisorLoginRequest : BaseRequest
    {
        public Guid AdvisorLoginId { get; set; }
        public Guid AdvisorId { get; set; }
        public DateTime AdvisorLoginDateTime { get; set; }
        public bool AdvisorLoginStage { get; set; }

        public static UpdateAdvisorLoginRequest FromDto(AdvisorLoginDto advisorLoginDto)
        {
            return new UpdateAdvisorLoginRequest
            {
                AdvisorLoginId = advisorLoginDto.AdvisorLoginId,
                AdvisorId = advisorLoginDto.AdvisorId,
                AdvisorLoginDateTime = advisorLoginDto.AdvisorLoginDateTime,
                AdvisorLoginStage = advisorLoginDto.AdvisorLoginStage
            };
        }
    }
}