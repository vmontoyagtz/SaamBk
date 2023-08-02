using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerReview;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerReviewEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerReviewRequest>.WithActionResult<
        UpdateCustomerReviewResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerReview> _repository;

        public Update(
            IRepository<CustomerReview> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerReviews")]
        [SwaggerOperation(
            Summary = "Updates a CustomerReview",
            Description = "Updates a CustomerReview",
            OperationId = "customerReviews.update",
            Tags = new[] { "CustomerReviewEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerReviewResponse>> HandleAsync(
            UpdateCustomerReviewRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerReviewResponse(request.CorrelationId());

            var crursrToUpdate = _mapper.Map<CustomerReview>(request);

            var customerReviewToUpdateTest = await _repository.GetByIdAsync(request.CustomerReviewId);
            if (customerReviewToUpdateTest is null)
            {
                return NotFound();
            }

            crursrToUpdate.UpdateAdvisorForCustomerReview(request.AdvisorId);
            crursrToUpdate.UpdateCustomerForCustomerReview(request.CustomerId);
            await _repository.UpdateAsync(crursrToUpdate);

            var customerReviewUpdatedEvent = new CustomerReviewUpdatedEvent(crursrToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerReviewUpdatedEvent);

            var dto = _mapper.Map<CustomerReviewDto>(crursrToUpdate);
            response.CustomerReview = dto;

            return Ok(response);
        }
    }
}