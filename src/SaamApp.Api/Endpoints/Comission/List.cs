using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Comission;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ComissionEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListComissionRequest>.WithActionResult<ListComissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Comission> _repository;

        public List(IRepository<Comission> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/comissions")]
        [SwaggerOperation(
            Summary = "List Comissions",
            Description = "List Comissions",
            OperationId = "comissions.List",
            Tags = new[] { "ComissionEndpoints" })
        ]
        public override async Task<ActionResult<ListComissionResponse>> HandleAsync(
            [FromQuery] ListComissionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListComissionResponse(request.CorrelationId());

            var spec = new ComissionGetListSpec();
            var comissions = await _repository.ListAsync(spec);
            if (comissions is null)
            {
                return NotFound();
            }

            response.Comissions = _mapper.Map<List<ComissionDto>>(comissions);
            response.Count = response.Comissions.Count;

            return Ok(response);
        }
    }
}