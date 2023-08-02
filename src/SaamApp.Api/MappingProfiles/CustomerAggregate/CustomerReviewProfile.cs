using AutoMapper;
using SaamApp.BlazorMauiShared.Models.CustomerReview;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;

namespace SaamApp.Api.MappingProfiles
{
    public class CustomerReviewProfile : Profile
    {
        public CustomerReviewProfile()
        {
            CreateMap<CustomerReview, CustomerReviewDto>();
            CreateMap<CustomerReviewDto, CustomerReview>();
            CreateMap<CreateCustomerReviewRequest, CustomerReview>();
            CreateMap<UpdateCustomerReviewRequest, CustomerReview>();
            CreateMap<DeleteCustomerReviewRequest, CustomerReview>();
        }
    }
}