using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustmentRef;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentRefEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAccountAdjustmentRefRequest>.WithActionResult<
        DeleteAccountAdjustmentRefResponse>
    {
        private readonly IRepository<AccountAdjustmentRef> _accountAdjustmentRefReadRepository;
        private readonly IRepository<AccountAdjustment> _accountAdjustmentRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountAdjustmentRef> _repository;

        public Delete(IRepository<AccountAdjustmentRef> AccountAdjustmentRefRepository,
            IRepository<AccountAdjustmentRef> AccountAdjustmentRefReadRepository,
            IRepository<AccountAdjustment> accountAdjustmentRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AccountAdjustmentRefRepository;
            _accountAdjustmentRefReadRepository = AccountAdjustmentRefReadRepository;
            _accountAdjustmentRepository = accountAdjustmentRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/accountAdjustmentRefs/{AccountAdjustmentRefId}")]
        [SwaggerOperation(
            Summary = "Deletes an AccountAdjustmentRef",
            Description = "Deletes an AccountAdjustmentRef",
            OperationId = "accountAdjustmentRefs.delete",
            Tags = new[] { "AccountAdjustmentRefEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAccountAdjustmentRefResponse>> HandleAsync(
            [FromRoute] DeleteAccountAdjustmentRefRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAccountAdjustmentRefResponse(request.CorrelationId());

            var accountAdjustmentRef =
                await _accountAdjustmentRefReadRepository.GetByIdAsync(request.AccountAdjustmentRefId);

            if (accountAdjustmentRef == null)
            {
                return NotFound();
            }

            var accountAdjustmentSpec =
                new GetAccountAdjustmentWithAccountAdjustmentRefKeySpec(accountAdjustmentRef.AccountAdjustmentRefId);
            var accountAdjustments = await _accountAdjustmentRepository.ListAsync(accountAdjustmentSpec);
            await _accountAdjustmentRepository
                .DeleteRangeAsync(accountAdjustments); // you could use soft delete with IsDeleted = true

            var accountAdjustmentRefDeletedEvent =
                new AccountAdjustmentRefDeletedEvent(accountAdjustmentRef, "Mongo-History");
            _messagePublisher.Publish(accountAdjustmentRefDeletedEvent);

            await _repository.DeleteAsync(accountAdjustmentRef);

            return Ok(response);
        }
    }
}