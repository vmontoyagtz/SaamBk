using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListFinancialAccountingPeriodRequest>.WithActionResult<
        ListFinancialAccountingPeriodResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<FinancialAccountingPeriod> _repository;

        public List(IRepository<FinancialAccountingPeriod> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/financialAccountingPeriods")]
        [SwaggerOperation(
            Summary = "List FinancialAccountingPeriods",
            Description = "List FinancialAccountingPeriods",
            OperationId = "financialAccountingPeriods.List",
            Tags = new[] { "FinancialAccountingPeriodEndpoints" })
        ]
        public override async Task<ActionResult<ListFinancialAccountingPeriodResponse>> HandleAsync(
            [FromQuery] ListFinancialAccountingPeriodRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListFinancialAccountingPeriodResponse(request.CorrelationId());

            var spec = new FinancialAccountingPeriodGetListSpec();
            var financialAccountingPeriods = await _repository.ListAsync(spec);
            if (financialAccountingPeriods is null)
            {
                return NotFound();
            }

            response.FinancialAccountingPeriods =
                _mapper.Map<List<FinancialAccountingPeriodDto>>(financialAccountingPeriods);
            response.Count = response.FinancialAccountingPeriods.Count;

            return Ok(response);
        }
    }
}