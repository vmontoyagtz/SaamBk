using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Account;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAccountRequest>.WithActionResult<ListAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Account> _repository;

        public List(IRepository<Account> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accounts")]
        [SwaggerOperation(
            Summary = "List Accounts",
            Description = "List Accounts",
            OperationId = "accounts.List",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<ListAccountResponse>> HandleAsync(
            [FromQuery] ListAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAccountResponse(request.CorrelationId());

            var spec = new AccountGetListSpec();
            var accounts = await _repository.ListAsync(spec);
            if (accounts is null)
            {
                return NotFound();
            }

            response.Accounts = _mapper.Map<List<AccountDto>>(accounts);
            response.Count = response.Accounts.Count;

            return Ok(response);
        }
    }
}