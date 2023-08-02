using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitAddressEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListBusinessUnitAddressRequest>.WithActionResult<
        ListBusinessUnitAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitAddress> _repository;

        public List(IRepository<BusinessUnitAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitAddresses")]
        [SwaggerOperation(
            Summary = "List BusinessUnitAddresses",
            Description = "List BusinessUnitAddresses",
            OperationId = "businessUnitAddresses.List",
            Tags = new[] { "BusinessUnitAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListBusinessUnitAddressResponse>> HandleAsync(
            [FromQuery] ListBusinessUnitAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBusinessUnitAddressResponse(request.CorrelationId());

            var spec = new BusinessUnitAddressGetListSpec();
            var businessUnitAddresses = await _repository.ListAsync(spec);
            if (businessUnitAddresses is null)
            {
                return NotFound();
            }

            response.BusinessUnitAddresses = _mapper.Map<List<BusinessUnitAddressDto>>(businessUnitAddresses);
            response.Count = response.BusinessUnitAddresses.Count;

            return Ok(response);
        }
    }
}