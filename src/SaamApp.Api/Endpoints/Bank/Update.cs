using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Bank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BankEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBankRequest>.WithActionResult<UpdateBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Bank> _repository;

        public Update(
            IRepository<Bank> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/banks")]
        [SwaggerOperation(
            Summary = "Updates a Bank",
            Description = "Updates a Bank",
            OperationId = "banks.update",
            Tags = new[] { "BankEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBankResponse>> HandleAsync(UpdateBankRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateBankResponse(request.CorrelationId());

            var banToUpdate = _mapper.Map<Bank>(request);

            var bankToUpdateTest = await _repository.GetByIdAsync(request.BankId);
            if (bankToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(banToUpdate);

            var bankUpdatedEvent = new BankUpdatedEvent(banToUpdate, "Mongo-History");
            _messagePublisher.Publish(bankUpdatedEvent);

            var dto = _mapper.Map<BankDto>(banToUpdate);
            response.Bank = dto;

            return Ok(response);
        }
    }
}