using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TrainingQuestionOption;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TrainingQuestionOptionEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListTrainingQuestionOptionRequest>.WithActionResult<
        ListTrainingQuestionOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingQuestionOption> _repository;

        public List(IRepository<TrainingQuestionOption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingQuestionOptions")]
        [SwaggerOperation(
            Summary = "List TrainingQuestionOptions",
            Description = "List TrainingQuestionOptions",
            OperationId = "trainingQuestionOptions.List",
            Tags = new[] { "TrainingQuestionOptionEndpoints" })
        ]
        public override async Task<ActionResult<ListTrainingQuestionOptionResponse>> HandleAsync(
            [FromQuery] ListTrainingQuestionOptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListTrainingQuestionOptionResponse(request.CorrelationId());

            var spec = new TrainingQuestionOptionGetListSpec();
            var trainingQuestionOptions = await _repository.ListAsync(spec);
            if (trainingQuestionOptions is null)
            {
                return NotFound();
            }

            response.TrainingQuestionOptions = _mapper.Map<List<TrainingQuestionOptionDto>>(trainingQuestionOptions);
            response.Count = response.TrainingQuestionOptions.Count;

            return Ok(response);
        }
    }
}