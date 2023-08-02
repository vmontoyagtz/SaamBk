using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BankAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankAccountEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdBankAccountRequest>.WithActionResult<
        GetByIdBankAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BankAccount> _repository;

        public GetByIdWithIncludes(
            IRepository<BankAccount> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/bankAccounts/i/{BankAccountId}")]
        [SwaggerOperation(
            Summary = "Get a BankAccount by Id With Includes",
            Description = "Gets a BankAccount by Id With Includes",
            OperationId = "bankAccounts.GetByIdWithIncludes",
            Tags = new[] { "BankAccountEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBankAccountResponse>> HandleAsync(
            [FromRoute] GetByIdBankAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBankAccountResponse(request.CorrelationId());

            var spec = new BankAccountByIdWithIncludesSpec(request.BankAccountId);

            var bankAccount = await _repository.FirstOrDefaultAsync(spec);


            if (bankAccount is null)
            {
                return NotFound();
            }

            response.BankAccount = _mapper.Map<BankAccountDto>(bankAccount);

            return Ok(response);
        }
    }
}