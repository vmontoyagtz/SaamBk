using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Gender;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GenderEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdGenderRequest>.WithActionResult<
        GetByIdGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Gender> _repository;

        public GetById(
            IRepository<Gender> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/genders/{GenderId}")]
        [SwaggerOperation(
            Summary = "Get a Gender by Id",
            Description = "Gets a Gender by Id",
            OperationId = "genders.GetById",
            Tags = new[] { "GenderEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdGenderResponse>> HandleAsync(
            [FromRoute] GetByIdGenderRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdGenderResponse(request.CorrelationId());

            var gender = await _repository.GetByIdAsync(request.GenderId);
            if (gender is null)
            {
                return NotFound();
            }

            response.Gender = _mapper.Map<GenderDto>(gender);

            return Ok(response);
        }
    }
}