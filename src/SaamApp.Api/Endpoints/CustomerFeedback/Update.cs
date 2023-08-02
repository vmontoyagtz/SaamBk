using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerFeedbackEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerFeedbackRequest>.WithActionResult<
        UpdateCustomerFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerFeedback> _repository;

        public Update(
            IRepository<CustomerFeedback> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerFeedbacks")]
        [SwaggerOperation(
            Summary = "Updates a CustomerFeedback",
            Description = "Updates a CustomerFeedback",
            OperationId = "customerFeedbacks.update",
            Tags = new[] { "CustomerFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerFeedbackResponse>> HandleAsync(
            UpdateCustomerFeedbackRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerFeedbackResponse(request.CorrelationId());

            var cfufsfToUpdate = _mapper.Map<CustomerFeedback>(request);

            var customerFeedbackToUpdateTest = await _repository.GetByIdAsync(request.FeedbackId);
            if (customerFeedbackToUpdateTest is null)
            {
                return NotFound();
            }

            cfufsfToUpdate.UpdateCustomerForCustomerFeedback(request.CustomerId);
            await _repository.UpdateAsync(cfufsfToUpdate);

            var customerFeedbackUpdatedEvent = new CustomerFeedbackUpdatedEvent(cfufsfToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerFeedbackUpdatedEvent);

            var dto = _mapper.Map<CustomerFeedbackDto>(cfufsfToUpdate);
            response.CustomerFeedback = dto;

            return Ok(response);
        }
    }
}