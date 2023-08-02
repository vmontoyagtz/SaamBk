using AutoMapper;
using SaamApp.BlazorMauiShared.Models.Invoice;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateMap<Invoice, InvoiceDto>();
            CreateMap<InvoiceDto, Invoice>();
            CreateMap<CreateInvoiceRequest, Invoice>();
            CreateMap<UpdateInvoiceRequest, Invoice>();
            CreateMap<DeleteInvoiceRequest, Invoice>();
        }
    }
}