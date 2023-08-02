using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Bank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdBankRequest>.WithActionResult<
        GetByIdBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Bank> _repository;

        public GetByIdWithIncludes(
            IRepository<Bank> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/banks/i/{BankId}")]
        [SwaggerOperation(
            Summary = "Get a Bank by Id With Includes",
            Description = "Gets a Bank by Id With Includes",
            OperationId = "banks.GetByIdWithIncludes",
            Tags = new[] { "BankEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBankResponse>> HandleAsync(
            [FromRoute] GetByIdBankRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBankResponse(request.CorrelationId());

            var spec = new BankByIdWithIncludesSpec(request.BankId);

            var bank = await _repository.FirstOrDefaultAsync(spec);


            if (bank is null)
            {
                return NotFound();
            }

            response.Bank = _mapper.Map<BankDto>(bank);

            return Ok(response);
        }
    }
}