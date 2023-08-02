using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Address;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAddressRequest>.WithActionResult<ListAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Address> _repository;

        public List(IRepository<Address> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/addresses")]
        [SwaggerOperation(
            Summary = "List Addresses",
            Description = "List Addresses",
            OperationId = "addresses.List",
            Tags = new[] { "AddressEndpoints" })
        ]
        public override async Task<ActionResult<ListAddressResponse>> HandleAsync(
            [FromQuery] ListAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAddressResponse(request.CorrelationId());

            var spec = new AddressGetListSpec();
            var addresses = await _repository.ListAsync(spec);
            if (addresses is null)
            {
                return NotFound();
            }

            response.Addresses = _mapper.Map<List<AddressDto>>(addresses);
            response.Count = response.Addresses.Count;

            return Ok(response);
        }
    }
}