using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AccountAdjustmentRefEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAccountAdjustmentRefRequest>.WithActionResult<
        UpdateAccountAdjustmentRefResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountAdjustmentRef> _repository;

        public Update(
            IRepository<AccountAdjustmentRef> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/accountAdjustmentRefs")]
        [SwaggerOperation(
            Summary = "Updates a AccountAdjustmentRef",
            Description = "Updates a AccountAdjustmentRef",
            OperationId = "accountAdjustmentRefs.update",
            Tags = new[] { "AccountAdjustmentRefEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAccountAdjustmentRefResponse>> HandleAsync(
            UpdateAccountAdjustmentRefRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAccountAdjustmentRefResponse(request.CorrelationId());

            var aarcarcarToUpdate = _mapper.Map<AccountAdjustmentRef>(request);

            var accountAdjustmentRefToUpdateTest = await _repository.GetByIdAsync(request.AccountAdjustmentRefId);
            if (accountAdjustmentRefToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(aarcarcarToUpdate);

            var accountAdjustmentRefUpdatedEvent =
                new AccountAdjustmentRefUpdatedEvent(aarcarcarToUpdate, "Mongo-History");
            _messagePublisher.Publish(accountAdjustmentRefUpdatedEvent);

            var dto = _mapper.Map<AccountAdjustmentRefDto>(aarcarcarToUpdate);
            response.AccountAdjustmentRef = dto;

            return Ok(response);
        }
    }
}