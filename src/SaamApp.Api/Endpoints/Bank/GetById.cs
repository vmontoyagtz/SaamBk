using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Bank;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBankRequest>.WithActionResult<
        GetByIdBankResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Bank> _repository;

        public GetById(
            IRepository<Bank> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/banks/{BankId}")]
        [SwaggerOperation(
            Summary = "Get a Bank by Id",
            Description = "Gets a Bank by Id",
            OperationId = "banks.GetById",
            Tags = new[] { "BankEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBankResponse>> HandleAsync(
            [FromRoute] GetByIdBankRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBankResponse(request.CorrelationId());

            var bank = await _repository.GetByIdAsync(request.BankId);
            if (bank is null)
            {
                return NotFound();
            }

            response.Bank = _mapper.Map<BankDto>(bank);

            return Ok(response);
        }
    }
}