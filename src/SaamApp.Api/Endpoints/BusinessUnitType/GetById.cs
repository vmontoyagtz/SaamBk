using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitTypeEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdBusinessUnitTypeRequest>.WithActionResult<
        GetByIdBusinessUnitTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<BusinessUnitType> _repository;

        public GetById(
            IRepository<BusinessUnitType> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/businessUnitTypes/{BusinessUnitTypeId}")]
        [SwaggerOperation(
            Summary = "Get a BusinessUnitType by Id",
            Description = "Gets a BusinessUnitType by Id",
            OperationId = "businessUnitTypes.GetById",
            Tags = new[] { "BusinessUnitTypeEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdBusinessUnitTypeResponse>> HandleAsync(
            [FromRoute] GetByIdBusinessUnitTypeRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdBusinessUnitTypeResponse(request.CorrelationId());

            var businessUnitType = await _repository.GetByIdAsync(request.BusinessUnitTypeId);
            if (businessUnitType is null)
            {
                return NotFound();
            }

            response.BusinessUnitType = _mapper.Map<BusinessUnitTypeDto>(businessUnitType);

            return Ok(response);
        }
    }
}