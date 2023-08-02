using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnit;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListBusinessUnitRequest>.WithActionResult<
        ListBusinessUnitResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnit> _repository;

        public List(IRepository<BusinessUnit> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnits")]
        [SwaggerOperation(
            Summary = "List BusinessUnits",
            Description = "List BusinessUnits",
            OperationId = "businessUnits.List",
            Tags = new[] { "BusinessUnitEndpoints" })
        ]
        public override async Task<ActionResult<ListBusinessUnitResponse>> HandleAsync(
            [FromQuery] ListBusinessUnitRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListBusinessUnitResponse(request.CorrelationId());

            var spec = new BusinessUnitGetListSpec();
            var businessUnits = await _repository.ListAsync(spec);
            if (businessUnits is null)
            {
                return NotFound();
            }

            response.BusinessUnits = _mapper.Map<List<BusinessUnitDto>>(businessUnits);
            response.Count = response.BusinessUnits.Count;

            return Ok(response);
        }
    }
}