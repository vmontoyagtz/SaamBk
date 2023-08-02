using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAccountEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsCustomerAccountRequest>.WithActionResult<
        GetByIdCustomerAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAccount> _repository;

        public GetByRelsIds(
            IRepository<CustomerAccount> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAccounts/{AccountId}/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerAccount by rel Ids",
            Description = "Gets a CustomerAccount by rel Ids",
            OperationId = "customerAccounts.GetByRelsIds",
            Tags = new[] { "CustomerAccountEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerAccountResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsCustomerAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerAccountResponse(request.CorrelationId());

            var spec = new CustomerAccountByRelIdsSpec(request.AccountId, request.CustomerId);

            var customerAccount = await _repository.FirstOrDefaultAsync(spec);


            if (customerAccount is null)
            {
                return NotFound();
            }

            response.CustomerAccount = _mapper.Map<CustomerAccountDto>(customerAccount);

            return Ok(response);
        }
    }
}