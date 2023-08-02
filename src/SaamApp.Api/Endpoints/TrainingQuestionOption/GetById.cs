using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestionOption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionOptionEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTrainingQuestionOptionRequest>.WithActionResult<
        GetByIdTrainingQuestionOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingQuestionOption> _repository;

        public GetById(
            IRepository<TrainingQuestionOption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingQuestionOptions/{TrainingQuestionOptionId}")]
        [SwaggerOperation(
            Summary = "Get a TrainingQuestionOption by Id",
            Description = "Gets a TrainingQuestionOption by Id",
            OperationId = "trainingQuestionOptions.GetById",
            Tags = new[] { "TrainingQuestionOptionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTrainingQuestionOptionResponse>> HandleAsync(
            [FromRoute] GetByIdTrainingQuestionOptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTrainingQuestionOptionResponse(request.CorrelationId());

            var trainingQuestionOption = await _repository.GetByIdAsync(request.TrainingQuestionOptionId);
            if (trainingQuestionOption is null)
            {
                return NotFound();
            }

            response.TrainingQuestionOption = _mapper.Map<TrainingQuestionOptionDto>(trainingQuestionOption);

            return Ok(response);
        }
    }
}