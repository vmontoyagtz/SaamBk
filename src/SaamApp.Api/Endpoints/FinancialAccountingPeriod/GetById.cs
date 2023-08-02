using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FinancialAccountingPeriodEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdFinancialAccountingPeriodRequest>.WithActionResult<
        GetByIdFinancialAccountingPeriodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FinancialAccountingPeriod> _repository;

        public GetById(
            IRepository<FinancialAccountingPeriod> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/financialAccountingPeriods/{FinancialAccountingPeriodId}")]
        [SwaggerOperation(
            Summary = "Get a FinancialAccountingPeriod by Id",
            Description = "Gets a FinancialAccountingPeriod by Id",
            OperationId = "financialAccountingPeriods.GetById",
            Tags = new[] { "FinancialAccountingPeriodEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdFinancialAccountingPeriodResponse>> HandleAsync(
            [FromRoute] GetByIdFinancialAccountingPeriodRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdFinancialAccountingPeriodResponse(request.CorrelationId());

            var financialAccountingPeriod = await _repository.GetByIdAsync(request.FinancialAccountingPeriodId);
            if (financialAccountingPeriod is null)
            {
                return NotFound();
            }

            response.FinancialAccountingPeriod = _mapper.Map<FinancialAccountingPeriodDto>(financialAccountingPeriod);

            return Ok(response);
        }
    }
}