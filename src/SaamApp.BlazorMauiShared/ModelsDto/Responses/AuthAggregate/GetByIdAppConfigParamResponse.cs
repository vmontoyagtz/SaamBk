using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class GetByIdAppConfigParamResponse : BaseResponse
    {
        public GetByIdAppConfigParamResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdAppConfigParamResponse()
        {
        }

        public AppConfigParamDto AppConfigParam { get; set; } = new();
    }
}