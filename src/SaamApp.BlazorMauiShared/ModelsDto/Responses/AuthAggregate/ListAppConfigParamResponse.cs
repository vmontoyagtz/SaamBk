using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class ListAppConfigParamResponse : BaseResponse
    {
        public ListAppConfigParamResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListAppConfigParamResponse()
        {
        }

        public List<AppConfigParamDto> AppConfigParams { get; set; } = new();

        public int Count { get; set; }
    }
}