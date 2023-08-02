using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AddressType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AddressTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListAddressTypeRequest>.WithActionResult<ListAddressTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AddressType> _repository;

        public List(IRepository<AddressType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/addressTypes")]
        [SwaggerOperation(
            Summary = "List AddressTypes",
            Description = "List AddressTypes",
            OperationId = "addressTypes.List",
            Tags = new[] { "AddressTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListAddressTypeResponse>> HandleAsync(
            [FromQuery] ListAddressTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAddressTypeResponse(request.CorrelationId());

            var spec = new AddressTypeGetListSpec();
            var addressTypes = await _repository.ListAsync(spec);
            if (addressTypes is null)
            {
                return NotFound();
            }

            response.AddressTypes = _mapper.Map<List<AddressTypeDto>>(addressTypes);
            response.Count = response.AddressTypes.Count;

            return Ok(response);
        }
    }
}