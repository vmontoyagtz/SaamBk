using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.FinancialAccountingPeriodEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateFinancialAccountingPeriodRequest>.WithActionResult<
        UpdateFinancialAccountingPeriodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<FinancialAccountingPeriod> _repository;

        public Update(
            IRepository<FinancialAccountingPeriod> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/financialAccountingPeriods")]
        [SwaggerOperation(
            Summary = "Updates a FinancialAccountingPeriod",
            Description = "Updates a FinancialAccountingPeriod",
            OperationId = "financialAccountingPeriods.update",
            Tags = new[] { "FinancialAccountingPeriodEndpoints" })
        ]
        public override async Task<ActionResult<UpdateFinancialAccountingPeriodResponse>> HandleAsync(
            UpdateFinancialAccountingPeriodRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateFinancialAccountingPeriodResponse(request.CorrelationId());

            var fapiapnapToUpdate = _mapper.Map<FinancialAccountingPeriod>(request);

            var financialAccountingPeriodToUpdateTest =
                await _repository.GetByIdAsync(request.FinancialAccountingPeriodId);
            if (financialAccountingPeriodToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(fapiapnapToUpdate);

            var financialAccountingPeriodUpdatedEvent =
                new FinancialAccountingPeriodUpdatedEvent(fapiapnapToUpdate, "Mongo-History");
            _messagePublisher.Publish(financialAccountingPeriodUpdatedEvent);

            var dto = _mapper.Map<FinancialAccountingPeriodDto>(fapiapnapToUpdate);
            response.FinancialAccountingPeriod = dto;

            return Ok(response);
        }
    }
}