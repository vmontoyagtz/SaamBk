using System;

namespace SaamApp.BlazorMauiShared.Models.AppConfigParam
{
    public class DeleteAppConfigParamRequest : BaseRequest
    {
        public Guid AppConfigParamId { get; set; }
    }
}