using AutoMapper;
using SaamApp.BlazorMauiShared.Models.JournalEntryReference;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class JournalEntryReferenceProfile : Profile
    {
        public JournalEntryReferenceProfile()
        {
            CreateMap<JournalEntryReference, JournalEntryReferenceDto>();
            CreateMap<JournalEntryReferenceDto, JournalEntryReference>();
            CreateMap<CreateJournalEntryReferenceRequest, JournalEntryReference>();
            CreateMap<UpdateJournalEntryReferenceRequest, JournalEntryReference>();
            CreateMap<DeleteJournalEntryReferenceRequest, JournalEntryReference>();
        }
    }
}