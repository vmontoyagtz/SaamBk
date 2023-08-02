using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestion;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionEndpoints
{
    public class GetById : EndpointBaseAsync.WithRequest<GetByIdTrainingQuestionRequest>.WithActionResult<
        GetByIdTrainingQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingQuestion> _repository;

        public GetById(
            IRepository<TrainingQuestion> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingQuestions/{TrainingQuestionId}")]
        [SwaggerOperation(
            Summary = "Get a TrainingQuestion by Id",
            Description = "Gets a TrainingQuestion by Id",
            OperationId = "trainingQuestions.GetById",
            Tags = new[] { "TrainingQuestionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTrainingQuestionResponse>> HandleAsync(
            [FromRoute] GetByIdTrainingQuestionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTrainingQuestionResponse(request.CorrelationId());

            var trainingQuestion = await _repository.GetByIdAsync(request.TrainingQuestionId);
            if (trainingQuestion is null)
            {
                return NotFound();
            }

            response.TrainingQuestion = _mapper.Map<TrainingQuestionDto>(trainingQuestion);

            return Ok(response);
        }
    }
}