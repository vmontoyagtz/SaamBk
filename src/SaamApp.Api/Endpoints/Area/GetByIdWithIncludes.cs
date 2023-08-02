using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Area;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AreaEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAreaRequest>.WithActionResult<
        GetByIdAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Area> _repository;

        public GetByIdWithIncludes(
            IRepository<Area> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/areas/i/{AreaId}")]
        [SwaggerOperation(
            Summary = "Get a Area by Id With Includes",
            Description = "Gets a Area by Id With Includes",
            OperationId = "areas.GetByIdWithIncludes",
            Tags = new[] { "AreaEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAreaResponse>> HandleAsync(
            [FromRoute] GetByIdAreaRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAreaResponse(request.CorrelationId());

            var spec = new AreaByIdWithIncludesSpec(request.AreaId);

            var area = await _repository.FirstOrDefaultAsync(spec);


            if (area is null)
            {
                return NotFound();
            }

            response.Area = _mapper.Map<AreaDto>(area);

            return Ok(response);
        }
    }
}