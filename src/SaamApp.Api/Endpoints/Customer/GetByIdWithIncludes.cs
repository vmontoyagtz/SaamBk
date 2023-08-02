using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEndpoints
{
    /// <summary>
    ///     This is an endpoint that handles a GET request to the endpoint "api/customers/i/{CustomerId}"
    ///     and uses the "CustomerByIdWithIncludesSpec" specification to retrieve the customer
    ///     with the specified id. The endpoint maps the retrieved customer to a CustomerDto
    ///     object and returns it in the response. If the customer is not found, the endpoint
    ///     returns a 404 Not Found status code. The endpoint also includes a summary, description,
    ///     and tags for the Swagger documentation.
    /// </summary>
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCustomerRequest>.WithActionResult<
        GetByIdCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        public GetByIdWithIncludes(
            IRepository<Customer> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customers/i/{CustomerId}")]
        [SwaggerOperation(
            Summary = "Get a Customer by Id With Includes",
            Description = "Gets a Customer by Id With Includes",
            OperationId = "customers.GetByIdWithIncludes",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerResponse(request.CorrelationId());

            var spec = new CustomerByIdWithIncludesSpec(request.CustomerId);

            var customer = await _repository.FirstOrDefaultAsync(spec);


            if (customer is null)
            {
                return NotFound();
            }

            response.Customer = _mapper.Map<CustomerDto>(customer);

            return Ok(response);
        }
    }
}