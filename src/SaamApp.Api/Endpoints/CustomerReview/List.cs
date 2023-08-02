using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListCustomerReviewRequest>.WithActionResult<
        ListCustomerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerReview> _repository;

        public List(IRepository<CustomerReview> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerReviews")]
        [SwaggerOperation(
            Summary = "List CustomerReviews",
            Description = "List CustomerReviews",
            OperationId = "customerReviews.List",
            Tags = new[] { "CustomerReviewEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerReviewResponse>> HandleAsync(
            [FromQuery] ListCustomerReviewRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerReviewResponse(request.CorrelationId());

            var spec = new CustomerReviewGetListSpec();
            var customerReviews = await _repository.ListAsync(spec);
            if (customerReviews is null)
            {
                return NotFound();
            }

            response.CustomerReviews = _mapper.Map<List<CustomerReviewDto>>(customerReviews);
            response.Count = response.CustomerReviews.Count;

            return Ok(response);
        }
    }
}