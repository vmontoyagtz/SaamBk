using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerPurchase;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerPurchaseEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerPurchaseRequest>.WithActionResult<
        GetByIdCustomerPurchaseResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerPurchase> _repository;

        public GetById(
            IRepository<CustomerPurchase> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerPurchases/{CustomerPurchaseId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerPurchase by Id",
            Description = "Gets a CustomerPurchase by Id",
            OperationId = "customerPurchases.GetById",
            Tags = new[] { "CustomerPurchaseEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerPurchaseResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerPurchaseRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerPurchaseResponse(request.CorrelationId());

            var customerPurchase = await _repository.GetByIdAsync(request.CustomerPurchaseId);
            if (customerPurchase is null)
            {
                return NotFound();
            }

            response.CustomerPurchase = _mapper.Map<CustomerPurchaseDto>(customerPurchase);

            return Ok(response);
        }
    }
}