using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnit;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBusinessUnitRequest>.WithActionResult<
        GetByIdBusinessUnitResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnit> _repository;

        public GetById(
            IRepository<BusinessUnit> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnits/{BusinessUnitId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnit by Id",
            Description = "Gets a BusinessUnit by Id",
            OperationId = "businessUnits.GetById",
            Tags = new[] { "BusinessUnitEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitResponse>> HandleAsync(
            [FromRoute] GetByIdBusinessUnitRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitResponse(request.CorrelationId());

            var businessUnit = await _repository.GetByIdAsync(request.BusinessUnitId);
            if (businessUnit is null)
            {
                return NotFound();
            }

            response.BusinessUnit = _mapper.Map<BusinessUnitDto>(businessUnit);

            return Ok(response);
        }
    }
}