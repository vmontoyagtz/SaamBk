using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PaymentFrequency;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.PaymentFrequencyEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdatePaymentFrequencyRequest>.WithActionResult<
        UpdatePaymentFrequencyResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PaymentFrequency> _repository;

        public Update(
            IRepository<PaymentFrequency> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/paymentFrequencies")]
        [SwaggerOperation(
            Summary = "Updates a PaymentFrequency",
            Description = "Updates a PaymentFrequency",
            OperationId = "paymentFrequencies.update",
            Tags = new[] { "PaymentFrequencyEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePaymentFrequencyResponse>> HandleAsync(
            UpdatePaymentFrequencyRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePaymentFrequencyResponse(request.CorrelationId());

            var pfafyfToUpdate = _mapper.Map<PaymentFrequency>(request);

            var paymentFrequencyToUpdateTest = await _repository.GetByIdAsync(request.PaymentFrequencyId);
            if (paymentFrequencyToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(pfafyfToUpdate);

            var paymentFrequencyUpdatedEvent = new PaymentFrequencyUpdatedEvent(pfafyfToUpdate, "Mongo-History");
            _messagePublisher.Publish(paymentFrequencyUpdatedEvent);

            var dto = _mapper.Map<PaymentFrequencyDto>(pfafyfToUpdate);
            response.PaymentFrequency = dto;

            return Ok(response);
        }
    }
}