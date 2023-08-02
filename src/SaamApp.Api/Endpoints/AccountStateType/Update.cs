using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AccountStateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.AccountStateTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateAccountStateTypeRequest>.WithActionResult<
        UpdateAccountStateTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<AccountStateType> _repository;

        public Update(
            IRepository<AccountStateType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/accountStateTypes")]
        [SwaggerOperation(
            Summary = "Updates a AccountStateType",
            Description = "Updates a AccountStateType",
            OperationId = "accountStateTypes.update",
            Tags = new[] { "AccountStateTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateAccountStateTypeResponse>> HandleAsync(
            UpdateAccountStateTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateAccountStateTypeResponse(request.CorrelationId());

            var astcstcstToUpdate = _mapper.Map<AccountStateType>(request);

            var accountStateTypeToUpdateTest = await _repository.GetByIdAsync(request.AccountStateTypeId);
            if (accountStateTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(astcstcstToUpdate);

            var accountStateTypeUpdatedEvent = new AccountStateTypeUpdatedEvent(astcstcstToUpdate, "Mongo-History");
            _messagePublisher.Publish(accountStateTypeUpdatedEvent);

            var dto = _mapper.Map<AccountStateTypeDto>(astcstcstToUpdate);
            response.AccountStateType = dto;

            return Ok(response);
        }
    }
}