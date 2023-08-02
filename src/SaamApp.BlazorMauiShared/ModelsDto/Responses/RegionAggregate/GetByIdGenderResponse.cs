using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class GetByIdGenderResponse : BaseResponse
    {
        public GetByIdGenderResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public GetByIdGenderResponse()
        {
        }

        public GenderDto Gender { get; set; } = new();
    }
}