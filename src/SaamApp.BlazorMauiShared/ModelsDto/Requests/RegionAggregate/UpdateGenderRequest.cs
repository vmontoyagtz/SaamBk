using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.Gender
{
    public class UpdateGenderRequest : BaseRequest
    {
        public Guid GenderId { get; set; }
        public string GenderName { get; set; }

        public static UpdateGenderRequest FromDto(GenderDto genderDto)
        {
            return new UpdateGenderRequest
            {
                GenderId = genderDto.GenderId,
                GenderName = genderDto.GenderName
            };
        }
    }
}