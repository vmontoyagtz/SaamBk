using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddress
{
    public class UpdateEmailAddressRequest : BaseRequest
    {
        public Guid EmailAddressId { get; set; }
        public string EmailAddressString { get; set; }

        public static UpdateEmailAddressRequest FromDto(EmailAddressDto emailAddressDto)
        {
            return new UpdateEmailAddressRequest
            {
                EmailAddressId = emailAddressDto.EmailAddressId,
                EmailAddressString = emailAddressDto.EmailAddressString
            };
        }
    }
}