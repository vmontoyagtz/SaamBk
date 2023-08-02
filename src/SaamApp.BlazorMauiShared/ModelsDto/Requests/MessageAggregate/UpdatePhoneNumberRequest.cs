using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.PhoneNumber
{
    public class UpdatePhoneNumberRequest : BaseRequest
    {
        public Guid PhoneNumberId { get; set; }
        public string PhoneNumberString { get; set; }

        public static UpdatePhoneNumberRequest FromDto(PhoneNumberDto phoneNumberDto)
        {
            return new UpdatePhoneNumberRequest
            {
                PhoneNumberId = phoneNumberDto.PhoneNumberId,
                PhoneNumberString = phoneNumberDto.PhoneNumberString
            };
        }
    }
}