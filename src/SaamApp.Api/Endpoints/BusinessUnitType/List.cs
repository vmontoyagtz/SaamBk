using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitTypeEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListBusinessUnitTypeRequest>.WithActionResult<
        ListBusinessUnitTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitType> _repository;

        public List(IRepository<BusinessUnitType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitTypes")]
        [SwaggerOperation(
            Summary = "List BusinessUnitTypes",
            Description = "List BusinessUnitTypes",
            OperationId = "businessUnitTypes.List",
            Tags = new[] { "BusinessUnitTypeEndpoints" })
        ]
        public override async Task<ActionResult<ListBusinessUnitTypeResponse>> HandleAsync(
            [FromQuery] ListBusinessUnitTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBusinessUnitTypeResponse(request.CorrelationId());

            var spec = new BusinessUnitTypeGetListSpec();
            var businessUnitTypes = await _repository.ListAsync(spec);
            if (businessUnitTypes is null)
            {
                return NotFound();
            }

            response.BusinessUnitTypes = _mapper.Map<List<BusinessUnitTypeDto>>(businessUnitTypes);
            response.Count = response.BusinessUnitTypes.Count;

            return Ok(response);
        }
    }
}