using AutoMapper;
using SaamApp.BlazorMauiShared.Models.VoiceNoteDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class VoiceNoteDocumentProfile : Profile
    {
        public VoiceNoteDocumentProfile()
        {
            CreateMap<VoiceNoteDocument, VoiceNoteDocumentDto>();
            CreateMap<VoiceNoteDocumentDto, VoiceNoteDocument>();
            CreateMap<CreateVoiceNoteDocumentRequest, VoiceNoteDocument>();
            CreateMap<UpdateVoiceNoteDocumentRequest, VoiceNoteDocument>();
            CreateMap<DeleteVoiceNoteDocumentRequest, VoiceNoteDocument>();
        }
    }
}