using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Area;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AreaEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAreaRequest>.WithActionResult<
        GetByIdAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Area> _repository;

        public GetById(
            IRepository<Area> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/areas/{AreaId}")]
        [SwaggerOperation(
            Summary = "Get a Area by Id",
            Description = "Gets a Area by Id",
            OperationId = "areas.GetById",
            Tags = new[] { "AreaEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAreaResponse>> HandleAsync(
            [FromRoute] GetByIdAreaRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAreaResponse(request.CorrelationId());

            var area = await _repository.GetByIdAsync(request.AreaId);
            if (area is null)
            {
                return NotFound();
            }

            response.Area = _mapper.Map<AreaDto>(area);

            return Ok(response);
        }
    }
}