using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.AiFeedback;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.AiFeedbackEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdAiFeedbackRequest>.WithActionResult<
        GetByIdAiFeedbackResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<AiFeedback> _repository;

        public GetById(
            IRepository<AiFeedback> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/aiFeedbacks/{AiFeedbackId}")]
        [SwaggerOperation(
            Summary = "Get a AiFeedback by Id",
            Description = "Gets a AiFeedback by Id",
            OperationId = "aiFeedbacks.GetById",
            Tags = new[] { "AiFeedbackEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdAiFeedbackResponse>> HandleAsync(
            [FromRoute] GetByIdAiFeedbackRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdAiFeedbackResponse(request.CorrelationId());

            var aiFeedback = await _repository.GetByIdAsync(request.AiFeedbackId);
            if (aiFeedback is null)
            {
                return NotFound();
            }

            response.AiFeedback = _mapper.Map<AiFeedbackDto>(aiFeedback);

            return Ok(response);
        }
    }
}