using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiFeedbackEndpoints
{
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdAiFeedbackRequest>.WithActionResult<
        GetByIdAiFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiFeedback> _repository;

        public GetByIdWithIncludes(
            IRepository<AiFeedback> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiFeedbacks/i/{AiFeedbackId}")]
        [SwaggerOperation(
            Summary = "Get a AiFeedback by Id With Includes",
            Description = "Gets a AiFeedback by Id With Includes",
            OperationId = "aiFeedbacks.GetByIdWithIncludes",
            Tags = new[] { "AiFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiFeedbackResponse>> HandleAsync(
            [FromRoute] GetByIdAiFeedbackRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiFeedbackResponse(request.CorrelationId());

            var spec = new AiFeedbackByIdWithIncludesSpec(request.AiFeedbackId);

            var aiFeedback = await _repository.FirstOrDefaultAsync(spec);


            if (aiFeedback is null)
            {
                return NotFound();
            }

            response.AiFeedback = _mapper.Map<AiFeedbackDto>(aiFeedback);

            return Ok(response);
        }
    }
}