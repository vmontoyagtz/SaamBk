using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.SerfinsaPayment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.SerfinsaPaymentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateSerfinsaPaymentRequest>.WithActionResult<
        UpdateSerfinsaPaymentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<SerfinsaPayment> _repository;

        public Update(
            IRepository<SerfinsaPayment> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/serfinsaPayments")]
        [SwaggerOperation(
            Summary = "Updates a SerfinsaPayment",
            Description = "Updates a SerfinsaPayment",
            OperationId = "serfinsaPayments.update",
            Tags = new[] { "SerfinsaPaymentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateSerfinsaPaymentResponse>> HandleAsync(
            UpdateSerfinsaPaymentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateSerfinsaPaymentResponse(request.CorrelationId());

            var speprpToUpdate = _mapper.Map<SerfinsaPayment>(request);

            var serfinsaPaymentToUpdateTest = await _repository.GetByIdAsync(request.SerfinsaPaymentId);
            if (serfinsaPaymentToUpdateTest is null)
            {
                return NotFound();
            }

            speprpToUpdate.UpdateCustomerForSerfinsaPayment(request.CustomerId);
            speprpToUpdate.UpdateDiscountCodeForSerfinsaPayment(request.DiscountCodeId);
            speprpToUpdate.UpdatePrepaidPackageForSerfinsaPayment(request.PrepaidPackageId);
            await _repository.UpdateAsync(speprpToUpdate);

            var serfinsaPaymentUpdatedEvent = new SerfinsaPaymentUpdatedEvent(speprpToUpdate, "Mongo-History");
            _messagePublisher.Publish(serfinsaPaymentUpdatedEvent);

            var dto = _mapper.Map<SerfinsaPaymentDto>(speprpToUpdate);
            response.SerfinsaPayment = dto;

            return Ok(response);
        }
    }
}