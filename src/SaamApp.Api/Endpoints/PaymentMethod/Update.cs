using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.PaymentMethod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.PaymentMethodEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdatePaymentMethodRequest>.WithActionResult<
        UpdatePaymentMethodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<PaymentMethod> _repository;

        public Update(
            IRepository<PaymentMethod> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/paymentMethods")]
        [SwaggerOperation(
            Summary = "Updates a PaymentMethod",
            Description = "Updates a PaymentMethod",
            OperationId = "paymentMethods.update",
            Tags = new[] { "PaymentMethodEndpoints" })
        ]
        public override async Task<ActionResult<UpdatePaymentMethodResponse>> HandleAsync(
            UpdatePaymentMethodRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdatePaymentMethodResponse(request.CorrelationId());

            var pmamymToUpdate = _mapper.Map<PaymentMethod>(request);

            var paymentMethodToUpdateTest = await _repository.GetByIdAsync(request.PaymentMethodId);
            if (paymentMethodToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(pmamymToUpdate);

            var paymentMethodUpdatedEvent = new PaymentMethodUpdatedEvent(pmamymToUpdate, "Mongo-History");
            _messagePublisher.Publish(paymentMethodUpdatedEvent);

            var dto = _mapper.Map<PaymentMethodDto>(pmamymToUpdate);
            response.PaymentMethod = dto;

            return Ok(response);
        }
    }
}