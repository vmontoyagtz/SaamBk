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
    public class GetByIdWithIncludes : EndpointBaseAsync.WithRequest<GetByIdTrainingQuestionOptionRequest>.
        WithActionResult<
            GetByIdTrainingQuestionOptionResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<TrainingQuestionOption> _repository;

        public GetByIdWithIncludes(
            IRepository<TrainingQuestionOption> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet("api/trainingQuestionOptions/i/{TrainingQuestionOptionId}")]
        [SwaggerOperation(
            Summary = "Get a TrainingQuestionOption by Id With Includes",
            Description = "Gets a TrainingQuestionOption by Id With Includes",
            OperationId = "trainingQuestionOptions.GetByIdWithIncludes",
            Tags = new[] { "TrainingQuestionOptionEndpoints" })
        ]
        public override async Task<ActionResult<GetByIdTrainingQuestionOptionResponse>> HandleAsync(
            [FromRoute] GetByIdTrainingQuestionOptionRequest request,
            CancellationToken cancellationToken)
        {
            var response = new GetByIdTrainingQuestionOptionResponse(request.CorrelationId());

            var spec = new TrainingQuestionOptionByIdWithIncludesSpec(request.TrainingQuestionOptionId);

            var trainingQuestionOption = await _repository.FirstOrDefaultAsync(spec);


            if (trainingQuestionOption is null)
            {
                return NotFound();
            }

            response.TrainingQuestionOption = _mapper.Map<TrainingQuestionOptionDto>(trainingQuestionOption);

            return Ok(response);
        }
    }
}