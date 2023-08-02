using AutoMapper;
using SaamApp.BlazorMauiShared.Models.AddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class AddressTypeProfile : Profile
    {
        public AddressTypeProfile()
        {
            CreateMap<AddressType, AddressTypeDto>();
            CreateMap<AddressTypeDto, AddressType>();
            CreateMap<CreateAddressTypeRequest, AddressType>();
            CreateMap<UpdateAddressTypeRequest, AddressType>();
            CreateMap<DeleteAddressTypeRequest, AddressType>();
        }
    }
}