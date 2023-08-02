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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAccountRequest>.WithActionResult<
        GetByIdAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Account> _repository;

        public GetByIdWithIncludes(
            IRepository<Account> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/accounts/i/{AccountId}")]
        [SwaggerOperation(
            Summary = "Get a Account by Id With Includes",
            Description = "Gets a Account by Id With Includes",
            OperationId = "accounts.GetByIdWithIncludes",
            Tags = new[] { "AccountEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAccountResponse>> HandleAsync(
            [FromRoute] GetByIdAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAccountResponse(request.CorrelationId());

            var spec = new AccountByIdWithIncludesSpec(request.AccountId);

            var account = await _repository.FirstOrDefaultAsync(spec);


            if (account is null)
            {
                return NotFound();
            }

            response.Account = _mapper.Map<AccountDto>(account);

            return Ok(response);
        }
    }
}