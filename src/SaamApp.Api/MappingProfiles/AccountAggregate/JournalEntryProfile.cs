using AutoMapper;
using SaamApp.BlazorMauiShared.Models.JournalEntry;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class JournalEntryProfile : Profile
    {
        public JournalEntryProfile()
        {
            CreateMap<JournalEntry, JournalEntryDto>();
            CreateMap<JournalEntryDto, JournalEntry>();
            CreateMap<CreateJournalEntryRequest, JournalEntry>();
            CreateMap<UpdateJournalEntryRequest, JournalEntry>();
            CreateMap<DeleteJournalEntryRequest, JournalEntry>();
        }
    }
}