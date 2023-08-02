using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerReview;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerReviewEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCustomerReviewRequest>.WithActionResult<
        GetByIdCustomerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerReview> _repository;

        public GetByIdWithIncludes(
            IRepository<CustomerReview> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerReviews/i/{CustomerReviewId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerReview by Id With Includes",
            Description = "Gets a CustomerReview by Id With Includes",
            OperationId = "customerReviews.GetByIdWithIncludes",
            Tags = new[] { "CustomerReviewEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerReviewResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerReviewRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerReviewResponse(request.CorrelationId());

            var spec = new CustomerReviewByIdWithIncludesSpec(request.CustomerReviewId);

            var customerReview = await _repository.FirstOrDefaultAsync(spec);


            if (customerReview is null)
            {
                return NotFound();
            }

            response.CustomerReview = _mapper.Map<CustomerReviewDto>(customerReview);

            return Ok(response);
        }
    }
}