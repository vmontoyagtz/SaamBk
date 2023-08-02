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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdCustomerPurchaseRequest>.WithActionResult<
        GetByIdCustomerPurchaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPurchase> _repository;

        public GetByIdWithIncludes(
            IRepository<CustomerPurchase> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPurchases/i/{CustomerPurchaseId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerPurchase by Id With Includes",
            Description = "Gets a CustomerPurchase by Id With Includes",
            OperationId = "customerPurchases.GetByIdWithIncludes",
            Tags = new[] { "CustomerPurchaseEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerPurchaseResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerPurchaseRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerPurchaseResponse(request.CorrelationId());

            var spec = new CustomerPurchaseByIdWithIncludesSpec(request.CustomerPurchaseId);

            var customerPurchase = await _repository.FirstOrDefaultAsync(spec);


            if (customerPurchase is null)
            {
                return NotFound();
            }

            response.CustomerPurchase = _mapper.Map<CustomerPurchaseDto>(customerPurchase);

            return Ok(response);
        }
    }
}