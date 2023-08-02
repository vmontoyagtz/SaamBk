using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AccountAdjustmentEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAccountAdjustmentRequest>.WithActionResult<
        UpdateAccountAdjustmentResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountAdjustment> _repository;

        public Update(
            IRepository<AccountAdjustment> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/accountAdjustments")]
        [SwaggerOperation(
            Summary = "Updates a AccountAdjustment",
            Description = "Updates a AccountAdjustment",
            OperationId = "accountAdjustments.update",
            Tags = new[] { "AccountAdjustmentEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAccountAdjustmentResponse>> HandleAsync(
            UpdateAccountAdjustmentRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAccountAdjustmentResponse(request.CorrelationId());

            var aacacaToUpdate = _mapper.Map<AccountAdjustment>(request);

            var accountAdjustmentToUpdateTest = await _repository.GetByIdAsync(request.AccountAdjustmentId);
            if (accountAdjustmentToUpdateTest is null)
            {
                return NotFound();
            }

            aacacaToUpdate.UpdateAccountForAccountAdjustment(request.AccountId);
            aacacaToUpdate.UpdateAccountAdjustmentRefForAccountAdjustment(request.AccountAdjustmentRefId);
            await _repository.UpdateAsync(aacacaToUpdate);

            var accountAdjustmentUpdatedEvent = new AccountAdjustmentUpdatedEvent(aacacaToUpdate, "Mongo-History");
            _messagePublisher.Publish(accountAdjustmentUpdatedEvent);

            var dto = _mapper.Map<AccountAdjustmentDto>(aacacaToUpdate);
            response.AccountAdjustment = dto;

            return Ok(response);
        }
    }
}