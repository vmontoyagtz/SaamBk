using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPurchase;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPurchaseEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCustomerPurchaseRequest>.WithActionResult<
        ListCustomerPurchaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPurchase> _repository;

        public List(IRepository<CustomerPurchase> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPurchases")]
        [SwaggerOperation(
            Summary = "List CustomerPurchases",
            Description = "List CustomerPurchases",
            OperationId = "customerPurchases.List",
            Tags = new[] { "CustomerPurchaseEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerPurchaseResponse>> HandleAsync(
            [FromQuery] ListCustomerPurchaseRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerPurchaseResponse(request.CorrelationId());

            var spec = new CustomerPurchaseGetListSpec();
            var customerPurchases = await _repository.ListAsync(spec);
            if (customerPurchases is null)
            {
                return NotFound();
            }

            response.CustomerPurchases = _mapper.Map<List<CustomerPurchaseDto>>(customerPurchases);
            response.Count = response.CustomerPurchases.Count;

            return Ok(response);
        }
    }
}