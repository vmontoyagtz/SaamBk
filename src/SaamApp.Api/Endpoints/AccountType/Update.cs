using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AccountTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAccountTypeRequest>.WithActionResult<
        UpdateAccountTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountType> _repository;

        public Update(
            IRepository<AccountType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/accountTypes")]
        [SwaggerOperation(
            Summary = "Updates a AccountType",
            Description = "Updates a AccountType",
            OperationId = "accountTypes.update",
            Tags = new[] { "AccountTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAccountTypeResponse>> HandleAsync(
            UpdateAccountTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAccountTypeResponse(request.CorrelationId());

            var atctctToUpdate = _mapper.Map<AccountType>(request);

            var accountTypeToUpdateTest = await _repository.GetByIdAsync(request.AccountTypeId);
            if (accountTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(atctctToUpdate);

            var accountTypeUpdatedEvent = new AccountTypeUpdatedEvent(atctctToUpdate, "Mongo-History");
            _messagePublisher.Publish(accountTypeUpdatedEvent);

            var dto = _mapper.Map<AccountTypeDto>(atctctToUpdate);
            response.AccountType = dto;

            return Ok(response);
        }
    }
}