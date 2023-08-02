using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListBankAccountRequest>.WithActionResult<ListBankAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BankAccount> _repository;

        public List(IRepository<BankAccount> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/bankAccounts")]
        [SwaggerOperation(
            Summary = "List BankAccounts",
            Description = "List BankAccounts",
            OperationId = "bankAccounts.List",
            Tags = new[] { "BankAccountEndpoints" })
        ]
        public override async Task<ActionResult<ListBankAccountResponse>> HandleAsync(
            [FromQuery] ListBankAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBankAccountResponse(request.CorrelationId());

            var spec = new BankAccountGetListSpec();
            var bankAccounts = await _repository.ListAsync(spec);
            if (bankAccounts is null)
            {
                return NotFound();
            }

            response.BankAccounts = _mapper.Map<List<BankAccountDto>>(bankAccounts);
            response.Count = response.BankAccounts.Count;

            return Ok(response);
        }
    }
}