using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountAdjustment;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountAdjustmentEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteAccountAdjustmentRequest>.WithActionResult<
        DeleteAccountAdjustmentResponse>
    {
        private readonly IRepository<AccountAdjustment> _accountAdjustmentReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountAdjustment> _repository;

        public Delete(IRepository<AccountAdjustment> AccountAdjustmentRepository,
            IRepository<AccountAdjustment> AccountAdjustmentReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = AccountAdjustmentRepository;
            _accountAdjustmentReadRepository = AccountAdjustmentReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/accountAdjustments/{AccountAdjustmentId}")]
        [SwaggerOperation(
            Summary = "Deletes an AccountAdjustment",
            Description = "Deletes an AccountAdjustment",
            OperationId = "accountAdjustments.delete",
            Tags = new[] { "AccountAdjustmentEndpoints" })
        ]
        public override async Task<ActionResult<DeleteAccountAdjustmentResponse>> HandleAsync(
            [FromRoute] DeleteAccountAdjustmentRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteAccountAdjustmentResponse(request.CorrelationId());

            var accountAdjustment = await _accountAdjustmentReadRepository.GetByIdAsync(request.AccountAdjustmentId);

            if (accountAdjustment == null)
            {
                return NotFound();
            }


            var accountAdjustmentDeletedEvent = new AccountAdjustmentDeletedEvent(accountAdjustment, "Mongo-History");
            _messagePublisher.Publish(accountAdjustmentDeletedEvent);

            await _repository.DeleteAsync(accountAdjustment);

            return Ok(response);
        }
    }
}