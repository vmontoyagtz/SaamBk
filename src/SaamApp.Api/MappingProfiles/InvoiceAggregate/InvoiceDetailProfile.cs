using AutoMapper;
using SaamApp.BlazorMauiShared.Models.InvoiceDetail;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class InvoiceDetailProfile : Profile
    {
        public InvoiceDetailProfile()
        {
            CreateMap<InvoiceDetail, InvoiceDetailDto>();
            CreateMap<InvoiceDetailDto, InvoiceDetail>();
            CreateMap<CreateInvoiceDetailRequest, InvoiceDetail>();
            CreateMap<UpdateInvoiceDetailRequest, InvoiceDetail>();
            CreateMap<DeleteInvoiceDetailRequest, InvoiceDetail>();
        }
    }
}