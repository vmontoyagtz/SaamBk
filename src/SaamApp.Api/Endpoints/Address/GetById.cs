using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Address;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAddressRequest>.WithActionResult<
        GetByIdAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Address> _repository;

        public GetById(
            IRepository<Address> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/addresses/{AddressId}")]
        [SwaggerOperation(
            Summary = "Get a Address by Id",
            Description = "Gets a Address by Id",
            OperationId = "addresses.GetById",
            Tags = new[] { "AddressEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAddressResponse>> HandleAsync(
            [FromRoute] GetByIdAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAddressResponse(request.CorrelationId());

            var address = await _repository.GetByIdAsync(request.AddressId);
            if (address is null)
            {
                return NotFound();
            }

            response.Address = _mapper.Map<AddressDto>(address);

            return Ok(response);
        }
    }
}