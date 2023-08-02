using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerAccount;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerAccountEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerAccountRequest>.WithActionResult<
        GetByIdCustomerAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAccount> _repository;

        public GetById(
            IRepository<CustomerAccount> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAccounts/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerAccount by Id",
            Description = "Gets a CustomerAccount by Id",
            OperationId = "customerAccounts.GetById",
            Tags = new[] { "CustomerAccountEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerAccountResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerAccountResponse(request.CorrelationId());

            var customerAccount = await _repository.GetByIdAsync(request.RowId);
            if (customerAccount is null)
            {
                return NotFound();
            }

            response.CustomerAccount = _mapper.Map<CustomerAccountDto>(customerAccount);

            return Ok(response);
        }
    }
}