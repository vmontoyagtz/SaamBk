using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAiHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAiHistoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCustomerAiHistoryRequest>.WithActionResult<
        DeleteCustomerAiHistoryResponse>
    {
        private readonly IRepository<CustomerAiHistory> _customerAiHistoryReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAiHistory> _repository;

        public Delete(IRepository<CustomerAiHistory> CustomerAiHistoryRepository,
            IRepository<CustomerAiHistory> CustomerAiHistoryReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CustomerAiHistoryRepository;
            _customerAiHistoryReadRepository = CustomerAiHistoryReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/customerAiHistories/{CustomerAiHistoryId}")]
        [SwaggerOperation(
            Summary = "Deletes an CustomerAiHistory",
            Description = "Deletes an CustomerAiHistory",
            OperationId = "customerAiHistories.delete",
            Tags = new[] { "CustomerAiHistoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCustomerAiHistoryResponse>> HandleAsync(
            [FromRoute] DeleteCustomerAiHistoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCustomerAiHistoryResponse(request.CorrelationId());

            var customerAiHistory = await _customerAiHistoryReadRepository.GetByIdAsync(request.CustomerAiHistoryId);

            if (customerAiHistory == null)
            {
                return NotFound();
            }


            var customerAiHistoryDeletedEvent = new CustomerAiHistoryDeletedEvent(customerAiHistory, "Mongo-History");
            _messagePublisher.Publish(customerAiHistoryDeletedEvent);

            await _repository.DeleteAsync(customerAiHistory);

            return Ok(response);
        }
    }
}