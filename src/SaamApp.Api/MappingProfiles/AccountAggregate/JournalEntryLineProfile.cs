using AutoMapper;
using SaamApp.BlazorMauiShared.Models.JournalEntryLine;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class JournalEntryLineProfile : Profile
    {
        public JournalEntryLineProfile()
        {
            CreateMap<JournalEntryLine, JournalEntryLineDto>();
            CreateMap<JournalEntryLineDto, JournalEntryLine>();
            CreateMap<CreateJournalEntryLineRequest, JournalEntryLine>();
            CreateMap<UpdateJournalEntryLineRequest, JournalEntryLine>();
            CreateMap<DeleteJournalEntryLineRequest, JournalEntryLine>();
        }
    }
}