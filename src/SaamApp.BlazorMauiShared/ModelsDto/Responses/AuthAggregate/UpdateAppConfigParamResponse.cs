using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class UpdateAppConfigParamResponse : BaseResponse
    {
        public UpdateAppConfigParamResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateAppConfigParamResponse()
        {
        }

        public AppConfigParamDto AppConfigParam { get; set; } = new();
    }
}