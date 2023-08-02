using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Gender;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GenderEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListGenderRequest>.WithActionResult<ListGenderResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Gender> _repository;

        public List(IRepository<Gender> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/genders")]
        [SwaggerOperation(
            Summary = "List Genders",
            Description = "List Genders",
            OperationId = "genders.List",
            Tags = new[] { "GenderEndpoints" })
        ]
        public override async Task<ActionResult<ListGenderResponse>> HandleAsync([FromQuery] ListGenderRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListGenderResponse(request.CorrelationId());

            var spec = new GenderGetListSpec();
            var genders = await _repository.ListAsync(spec);
            if (genders is null)
            {
                return NotFound();
            }

            response.Genders = _mapper.Map<List<GenderDto>>(genders);
            response.Count = response.Genders.Count;

            return Ok(response);
        }
    }
}