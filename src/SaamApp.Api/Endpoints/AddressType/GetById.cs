using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAddressTypeRequest>.WithActionResult<
        GetByIdAddressTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AddressType> _repository;

        public GetById(
            IRepository<AddressType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/addressTypes/{AddressTypeId}")]
        [SwaggerOperation(
            Summary = "Get a AddressType by Id",
            Description = "Gets a AddressType by Id",
            OperationId = "addressTypes.GetById",
            Tags = new[] { "AddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAddressTypeResponse>> HandleAsync(
            [FromRoute] GetByIdAddressTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAddressTypeResponse(request.CorrelationId());

            var addressType = await _repository.GetByIdAsync(request.AddressTypeId);
            if (addressType is null)
            {
                return NotFound();
            }

            response.AddressType = _mapper.Map<AddressTypeDto>(addressType);

            return Ok(response);
        }
    }
}