using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BankAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BankAccountEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBankAccountRequest>.WithActionResult<
        GetByIdBankAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BankAccount> _repository;

        public GetById(
            IRepository<BankAccount> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/bankAccounts/{BankAccountId}")]
        [SwaggerOperation(
            Summary = "Get a BankAccount by Id",
            Description = "Gets a BankAccount by Id",
            OperationId = "bankAccounts.GetById",
            Tags = new[] { "BankAccountEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBankAccountResponse>> HandleAsync(
            [FromRoute] GetByIdBankAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBankAccountResponse(request.CorrelationId());

            var bankAccount = await _repository.GetByIdAsync(request.BankAccountId);
            if (bankAccount is null)
            {
                return NotFound();
            }

            response.BankAccount = _mapper.Map<BankAccountDto>(bankAccount);

            return Ok(response);
        }
    }
}