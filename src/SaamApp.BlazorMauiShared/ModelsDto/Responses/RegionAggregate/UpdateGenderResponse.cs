using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class UpdateGenderResponse : BaseResponse
    {
        public UpdateGenderResponse(Guid correlationId)
            : base(correlationId)
        {
        }

        public UpdateGenderResponse()
        {
        }

        public GenderDto Gender { get; set; } = new();
    }
}