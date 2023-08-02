using System;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.BlazorMauiShared.Models.EmailAddressType
{
    public class UpdateEmailAddressTypeRequest : BaseRequest
    {
        public Guid EmailAddressTypeId { get; set; }
        public string EmailAddressTypeName { get; set; }
        public string? Description { get; set; }
        public Guid TenantId { get; set; }

        public static UpdateEmailAddressTypeRequest FromDto(EmailAddressTypeDto emailAddressTypeDto)
        {
            return new UpdateEmailAddressTypeRequest
            {
                EmailAddressTypeId = emailAddressTypeDto.EmailAddressTypeId,
                EmailAddressTypeName = emailAddressTypeDto.EmailAddressTypeName,
                Description = emailAddressTypeDto.Description,
                TenantId = emailAddressTypeDto.TenantId
            };
        }
    }
}