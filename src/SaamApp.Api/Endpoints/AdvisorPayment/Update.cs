using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AdvisorPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AdvisorPaymentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAdvisorPaymentRequest>.WithActionResult<
        UpdateAdvisorPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AdvisorPayment> _repository;

        public Update(
            IRepository<AdvisorPayment> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/advisorPayments")]
        [SwaggerOperation(
            Summary = "Updates a AdvisorPayment",
            Description = "Updates a AdvisorPayment",
            OperationId = "advisorPayments.update",
            Tags = new[] { "AdvisorPaymentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAdvisorPaymentResponse>> HandleAsync(
            UpdateAdvisorPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAdvisorPaymentResponse(request.CorrelationId());

            var apdpvpToUpdate = _mapper.Map<AdvisorPayment>(request);

            var advisorPaymentToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (advisorPaymentToUpdateTest is null)
            {
                return NotFound();
            }

            apdpvpToUpdate.UpdateAdvisorForAdvisorPayment(request.AdvisorId);
            apdpvpToUpdate.UpdateBankAccountForAdvisorPayment(request.BankAccountId);
            apdpvpToUpdate.UpdatePaymentMethodForAdvisorPayment(request.PaymentMethodId);
            await _repository.UpdateAsync(apdpvpToUpdate);

            var advisorPaymentUpdatedEvent = new AdvisorPaymentUpdatedEvent(apdpvpToUpdate, "Mongo-History");
            _messagePublisher.Publish(advisorPaymentUpdatedEvent);

            var dto = _mapper.Map<AdvisorPaymentDto>(apdpvpToUpdate);
            response.AdvisorPayment = dto;

            return Ok(response);
        }
    }
}