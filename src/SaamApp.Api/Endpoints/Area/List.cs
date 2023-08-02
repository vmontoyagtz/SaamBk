using System.Collections.Generic;
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
    public class List : EndpointBaseAsync.WithRequest<ListAreaRequest>.WithActionResult<ListAreaResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Area> _repository;

        public List(IRepository<Area> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/areas")]
        [SwaggerOperation(
            Summary = "List Areas",
            Description = "List Areas",
            OperationId = "areas.List",
            Tags = new[] { "AreaEndpoints" })
        ]
        public override async Task<ActionResult<ListAreaResponse>> HandleAsync([FromQuery] ListAreaRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListAreaResponse(request.CorrelationId());

            var spec = new AreaGetListSpec();
            var areas = await _repository.ListAsync(spec);
            if (areas is null)
            {
                return NotFound();
            }

            response.Areas = _mapper.Map<List<AreaDto>>(areas);
            response.Count = response.Areas.Count;

            return Ok(response);
        }
    }
}