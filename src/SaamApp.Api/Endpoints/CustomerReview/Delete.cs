using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerReview;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerReviewEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerReviewRequest>.WithActionResult<
        DeleteCustomerReviewResponse>
    {
        private readonly IRepository<CustomerReview> _customerReviewReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerReview> _repository;

        public Delete(IRepository<CustomerReview> CustomerReviewRepository,
            IRepository<CustomerReview> CustomerReviewReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerReviewRepository;
            _customerReviewReadRepository = CustomerReviewReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerReviews/{CustomerReviewId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerReview",
            Description = "Deletes an CustomerReview",
            OperationId = "customerReviews.delete",
            Tags = new[] { "CustomerReviewEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerReviewResponse>> HandleAsync(
            [FromRoute] DeleteCustomerReviewRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerReviewResponse(request.CorrelationId());

            var customerReview = await _customerReviewReadRepository.GetByIdAsync(request.CustomerReviewId);

            if (customerReview == null)
            {
                return NotFound();
            }


            var customerReviewDeletedEvent = new CustomerReviewDeletedEvent(customerReview, "Mongo-History");
            _messagePublisher.Publish(customerReviewDeletedEvent);

            await _repository.DeleteAsync(customerReview);

            return Ok(response);
        }
    }
}