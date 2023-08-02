using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.CustomerEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEmailAddressEndpoints
{
    public class GetByRelsIds : EndpointBaseAsync.WithRequest<GetByRelsIdsCustomerEmailAddressRequest>.WithActionResult<
        GetByIdCustomerEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<CustomerEmailAddress> _repository;

        public GetByRelsIds(
            IRepository<CustomerEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/customerEmailAddresses/{CustomerId}/{EmailAddressId}")]
        [SwaggerOperation(
            Summary = "Get a CustomerEmailAddress by rel Ids",
            Description = "Gets a CustomerEmailAddress by rel Ids",
            OperationId = "customerEmailAddresses.GetByRelsIds",
            Tags = new[] { "CustomerEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdCustomerEmailAddressResponse>> HandleAsync(
            [FromRoute] GetByRelsIdsCustomerEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdCustomerEmailAddressResponse(request.CorrelationId());

            var spec = new CustomerEmailAddressByRelIdsSpec(request.CustomerId, request.EmailAddressId);

            var customerEmailAddress = await _repository.FirstOrDefaultAsync(spec);


            if (customerEmailAddress is null)
            {
                return NotFound();
            }

            response.CustomerEmailAddress = _mapper.Map<CustomerEmailAddressDto>(customerEmailAddress);

            return Ok(response);
        }
    }
}