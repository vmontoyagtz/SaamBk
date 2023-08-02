using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEmailAddressEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListBusinessUnitEmailAddressRequest>.WithActionResult<
        ListBusinessUnitEmailAddressResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitEmailAddress> _repository;

        public List(IRepository<BusinessUnitEmailAddress> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitEmailAddresses")]
        [SwaggerOperation(
            Summary = "List BusinessUnitEmailAddresses",
            Description = "List BusinessUnitEmailAddresses",
            OperationId = "businessUnitEmailAddresses.List",
            Tags = new[] { "BusinessUnitEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<ListBusinessUnitEmailAddressResponse>> HandleAsync(
            [FromQuery] ListBusinessUnitEmailAddressRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBusinessUnitEmailAddressResponse(request.CorrelationId());

            var spec = new BusinessUnitEmailAddressGetListSpec();
            var businessUnitEmailAddresses = await _repository.ListAsync(spec);
            if (businessUnitEmailAddresses is null)
            {
                return NotFound();
            }

            response.BusinessUnitEmailAddresses =
                _mapper.Map<List<BusinessUnitEmailAddressDto>>(businessUnitEmailAddresses);
            response.Count = response.BusinessUnitEmailAddresses.Count;

            return Ok(response);
        }
    }
}