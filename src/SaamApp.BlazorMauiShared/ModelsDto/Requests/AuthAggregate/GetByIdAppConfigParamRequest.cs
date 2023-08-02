using System;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class GetByIdAppConfigParamRequest : BaseRequest
    {
        public Guid AppConfigParamId { get; set; }
    }
}