using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class CreateAppConfigParamResponse : BaseResponse
    {
        public CreateAppConfigParamResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public CreateAppConfigParamResponse()
        {
        }

        public AppConfigParamDto AppConfigParam { get; set; } = new();
    }
}