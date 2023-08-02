using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TemplateTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTemplateTypeRequest>.WithActionResult<
        UpdateTemplateTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateType> _repository;

        public Update(
            IRepository<TemplateType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/templateTypes")]
        [SwaggerOperation(
            Summary = "Updates a TemplateType",
            Description = "Updates a TemplateType",
            OperationId = "templateTypes.update",
            Tags = new[] { "TemplateTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTemplateTypeResponse>> HandleAsync(
            UpdateTemplateTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTemplateTypeResponse(request.CorrelationId());

            var ttetmtToUpdate = _mapper.Map<TemplateType>(request);

            var templateTypeToUpdateTest = await _repository.GetByIdAsync(request.TemplateTypeId);
            if (templateTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(ttetmtToUpdate);

            var templateTypeUpdatedEvent = new TemplateTypeUpdatedEvent(ttetmtToUpdate, "Mongo-History");
            _messagePublisher.Publish(templateTypeUpdatedEvent);

            var dto = _mapper.Map<TemplateTypeDto>(ttetmtToUpdate);
            response.TemplateType = dto;

            return Ok(response);
        }
    }
}