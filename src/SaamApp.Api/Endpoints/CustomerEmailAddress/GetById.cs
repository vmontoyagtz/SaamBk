using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEmailAddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdCustomerEmailAddressRequest>.WithActionResult<
        GetByIdCustomerEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerEmailAddress> _repository;

        public GetById(
            IRepository<CustomerEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerEmailAddress by Id",
            Description = "Gets a CustomerEmailAddress by Id",
            OperationId = "customerEmailAddresses.GetById",
            Tags = new[] { "CustomerEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByIdCustomerEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerEmailAddressResponse(request.CorrelationId());

            var customerEmailAddress = await _repository.GetByIdAsync(request.RowId);
            if (customerEmailAddress is null)
            {
                return NotFound();
            }

            response.CustomerEmailAddress = _mapper.Map<CustomerEmailAddressDto>(customerEmailAddress);

            return Ok(response);
        }
    }
}