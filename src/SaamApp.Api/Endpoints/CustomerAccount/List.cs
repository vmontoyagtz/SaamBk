using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListCustomerAccountRequest>.WithActionResult<
        ListCustomerAccountResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerAccount> _repository;

        public List(IRepository<CustomerAccount> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerAccounts")]
        [SwaggerOperation(
            Summary = "List CustomerAccounts",
            Description = "List CustomerAccounts",
            OperationId = "customerAccounts.List",
            Tags = new[] { "CustomerAccountEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerAccountResponse>> HandleAsync(
            [FromQuery] ListCustomerAccountRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerAccountResponse(request.CorrelationId());

            var spec = new CustomerAccountGetListSpec();
            var customerAccounts = await _repository.ListAsync(spec);
            if (customerAccounts is null)
            {
                return NotFound();
            }

            response.CustomerAccounts = _mapper.Map<List<CustomerAccountDto>>(customerAccounts);
            response.Count = response.CustomerAccounts.Count;

            return Ok(response);
        }
    }
}