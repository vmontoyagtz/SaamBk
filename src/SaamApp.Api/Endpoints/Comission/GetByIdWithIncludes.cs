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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdComissionRequest>.WithActionResult<
        GetByIdComissionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Comission> _repository;

        public GetByIdWithIncludes(
            IRepository<Comission> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/comissions/i/{ComissionId}")]
        [SwaggerOperation(
            Summary = "Get a Comission by Id With Includes",
            Description = "Gets a Comission by Id With Includes",
            OperationId = "comissions.GetByIdWithIncludes",
            Tags = new[] { "ComissionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdComissionResponse>> HandleAsync(
            [FromRoute] GetByIdComissionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdComissionResponse(request.CorrelationId());

            var spec = new ComissionByIdWithIncludesSpec(request.ComissionId);

            var comission = await _repository.FirstOrDefaultAsync(spec);


            if (comission is null)
            {
                return NotFound();
            }

            response.Comission = _mapper.Map<ComissionDto>(comission);

            return Ok(response);
        }
    }
}