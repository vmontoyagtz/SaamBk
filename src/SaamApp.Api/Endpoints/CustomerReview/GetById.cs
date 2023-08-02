using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerReview;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerReviewEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerReviewRequest>.WithActionResult<
        GetByIdCustomerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerReview> _repository;

        public GetById(
            IRepository<CustomerReview> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerReviews/{CustomerReviewId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerReview by Id",
            Description = "Gets a CustomerReview by Id",
            OperationId = "customerReviews.GetById",
            Tags = new[] { "CustomerReviewEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerReviewResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerReviewRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerReviewResponse(request.CorrelationId());

            var customerReview = await _repository.GetByIdAsync(request.CustomerReviewId);
            if (customerReview is null)
            {
                return NotFound();
            }

            response.CustomerReview = _mapper.Map<CustomerReviewDto>(customerReview);

            return Ok(response);
        }
    }
}