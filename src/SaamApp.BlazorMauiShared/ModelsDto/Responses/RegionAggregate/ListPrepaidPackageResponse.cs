using System;
using System.Collections.Generic;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PrepaidPackage
{
    public class ListPrepaidPackageResponse : BaseResponse
    {
        public ListPrepaidPackageResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public ListPrepaidPackageResponse()
        {
        }

        public List<PrepaidPackageDto> PrepaidPackages { get; set; } = new();

        public int Count { get; set; }
    }
}