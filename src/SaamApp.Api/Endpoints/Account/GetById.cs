using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Account;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AccountEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAccountRequest>.WithActionResult<
        GetByIdAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Account> _repository;

        public GetById(
            IRepository<Account> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accounts/{AccountId}")]
        [SwaggerOperation(
            Summary = "Get a Account by Id",
            Description = "Gets a Account by Id",
            OperationId = "accounts.GetById",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAccountResponse>> HandleAsync(
            [FromRoute] GetByIdAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAccountResponse(request.CorrelationId());

            var account = await _repository.GetByIdAsync(request.AccountId);
            if (account is null)
            {
                return NotFound();
            }

            response.Account = _mapper.Map<AccountDto>(account);

            return Ok(response);
        }
    }
}