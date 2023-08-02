using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Comission
{
    public class GetByIdComissionResponse : BaseResponse
    {
        public GetByIdComissionResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdComissionResponse()
        {
        }

        public ComissionDto Comission { get; set; } = new();
    }
}