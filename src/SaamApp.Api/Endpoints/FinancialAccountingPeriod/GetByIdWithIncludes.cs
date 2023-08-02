using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.FinancialAccountingPeriod;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.FinancialAccountingPeriodEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdFinancialAccountingPeriodRequest>.
        WithActionResult<
            GetByIdFinancialAccountingPeriodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FinancialAccountingPeriod> _repository;

        public GetByIdWithIncludes(
            IRepository<FinancialAccountingPeriod> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/financialAccountingPeriods/i/{FinancialAccountingPeriodId}")]
        [SwaggerOperation(
            Summary = "Get a FinancialAccountingPeriod by Id With Includes",
            Description = "Gets a FinancialAccountingPeriod by Id With Includes",
            OperationId = "financialAccountingPeriods.GetByIdWithIncludes",
            Tags = new[] { "FinancialAccountingPeriodEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdFinancialAccountingPeriodResponse>> HandleAsync(
            [FromRoute] GetByIdFinancialAccountingPeriodRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdFinancialAccountingPeriodResponse(request.CorrelationId());

            var spec = new FinancialAccountingPeriodByIdWithIncludesSpec(request.FinancialAccountingPeriodId);

            var financialAccountingPeriod = await _repository.FirstOrDefaultAsync(spec);


            if (financialAccountingPeriod is null)
            {
                return NotFound();
            }

            response.FinancialAccountingPeriod = _mapper.Map<FinancialAccountingPeriodDto>(financialAccountingPeriod);

            return Ok(response);
        }
    }
}