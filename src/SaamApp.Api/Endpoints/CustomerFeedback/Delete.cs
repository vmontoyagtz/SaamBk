using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerFeedbackEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerFeedbackRequest>.WithActionResult<
        DeleteCustomerFeedbackResponse>
    {
        private readonly IRepository<CustomerFeedback> _customerFeedbackReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerFeedback> _repository;

        public Delete(IRepository<CustomerFeedback> CustomerFeedbackRepository,
            IRepository<CustomerFeedback> CustomerFeedbackReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerFeedbackRepository;
            _customerFeedbackReadRepository = CustomerFeedbackReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerFeedbacks/{FeedbackId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerFeedback",
            Description = "Deletes an CustomerFeedback",
            OperationId = "customerFeedbacks.delete",
            Tags = new[] { "CustomerFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerFeedbackResponse>> HandleAsync(
            [FromRoute] DeleteCustomerFeedbackRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerFeedbackResponse(request.CorrelationId());

            var customerFeedback = await _customerFeedbackReadRepository.GetByIdAsync(request.FeedbackId);

            if (customerFeedback == null)
            {
                return NotFound();
            }


            var customerFeedbackDeletedEvent = new CustomerFeedbackDeletedEvent(customerFeedback, "Mongo-History");
            _messagePublisher.Publish(customerFeedbackDeletedEvent);

            await _repository.DeleteAsync(customerFeedback);

            return Ok(response);
        }
    }
}