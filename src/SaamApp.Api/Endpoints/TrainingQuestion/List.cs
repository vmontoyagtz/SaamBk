using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestion;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTrainingQuestionRequest>.WithActionResult<
        ListTrainingQuestionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingQuestion> _repository;

        public List(IRepository<TrainingQuestion> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingQuestions")]
        [SwaggerOperation(
            Summary = "List TrainingQuestions",
            Description = "List TrainingQuestions",
            OperationId = "trainingQuestions.List",
            Tags = new[] { "TrainingQuestionEndpoints" })
        ]
        public override async Task<ActionResult<ListTrainingQuestionResponse>> HandleAsync(
            [FromQuery] ListTrainingQuestionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTrainingQuestionResponse(request.CorrelationId());

            var spec = new TrainingQuestionGetListSpec();
            var trainingQuestions = await _repository.ListAsync(spec);
            if (trainingQuestions is null)
            {
                return NotFound();
            }

            response.TrainingQuestions = _mapper.Map<List<TrainingQuestionDto>>(trainingQuestions);
            response.Count = response.TrainingQuestions.Count;

            return Ok(response);
        }
    }
}