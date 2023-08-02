using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAiHistory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CustomerAiHistoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCustomerAiHistoryRequest>.WithActionResult<
        UpdateCustomerAiHistoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerAiHistory> _repository;

        public Update(
            IRepository<CustomerAiHistory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/customerAiHistories")]
        [SwaggerOperation(
            Summary = "Updates a CustomerAiHistory",
            Description = "Updates a CustomerAiHistory",
            OperationId = "customerAiHistories.update",
            Tags = new[] { "CustomerAiHistoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCustomerAiHistoryResponse>> HandleAsync(
            UpdateCustomerAiHistoryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateCustomerAiHistoryResponse(request.CorrelationId());

            var cahuahsahToUpdate = _mapper.Map<CustomerAiHistory>(request);

            var customerAiHistoryToUpdateTest = await _repository.GetByIdAsync(request.CustomerAiHistoryId);
            if (customerAiHistoryToUpdateTest is null)
            {
                return NotFound();
            }

            cahuahsahToUpdate.UpdateCustomerForCustomerAiHistory(request.CustomerId);
            await _repository.UpdateAsync(cahuahsahToUpdate);

            var customerAiHistoryUpdatedEvent = new CustomerAiHistoryUpdatedEvent(cahuahsahToUpdate, "Mongo-History");
            _messagePublisher.Publish(customerAiHistoryUpdatedEvent);

            var dto = _mapper.Map<CustomerAiHistoryDto>(cahuahsahToUpdate);
            response.CustomerAiHistory = dto;

            return Ok(response);
        }
    }
}