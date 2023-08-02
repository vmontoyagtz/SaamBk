using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Template;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TemplateEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTemplateRequest>.WithActionResult<UpdateTemplateResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Template> _repository;

        public Update(
            IRepository<Template> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/templates")]
        [SwaggerOperation(
            Summary = "Updates a Template",
            Description = "Updates a Template",
            OperationId = "templates.update",
            Tags = new[] { "TemplateEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTemplateResponse>> HandleAsync(UpdateTemplateRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateTemplateResponse(request.CorrelationId());

            var temToUpdate = _mapper.Map<Template>(request);

            var templateToUpdateTest = await _repository.GetByIdAsync(request.TemplateId);
            if (templateToUpdateTest is null)
            {
                return NotFound();
            }

            // temToUpdate.UpdateTemplateTypeForTemplate(request.TemplateTypeId);
            await _repository.UpdateAsync(temToUpdate);

            var templateUpdatedEvent = new TemplateUpdatedEvent(temToUpdate, "Mongo-History");
            _messagePublisher.Publish(templateUpdatedEvent);

            var dto = _mapper.Map<TemplateDto>(temToUpdate);
            response.Template = dto;

            return Ok(response);
        }
    }
}