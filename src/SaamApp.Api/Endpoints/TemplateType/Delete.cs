using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TemplateType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TemplateTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTemplateTypeRequest>.WithActionResult<
        DeleteTemplateTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TemplateType> _repository;
        private readonly IRepository<Template> _templateRepository;
        private readonly IRepository<TemplateType> _templateTypeReadRepository;

        public Delete(IRepository<TemplateType> TemplateTypeRepository,
            IRepository<TemplateType> TemplateTypeReadRepository,
            IRepository<Template> templateRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TemplateTypeRepository;
            _templateTypeReadRepository = TemplateTypeReadRepository;
            _templateRepository = templateRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/templateTypes/{TemplateTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an TemplateType",
            Description = "Deletes an TemplateType",
            OperationId = "templateTypes.delete",
            Tags = new[] { "TemplateTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTemplateTypeResponse>> HandleAsync(
            [FromRoute] DeleteTemplateTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTemplateTypeResponse(request.CorrelationId());

            var templateType = await _templateTypeReadRepository.GetByIdAsync(request.TemplateTypeId);

            if (templateType == null)
            {
                return NotFound();
            }

            var templateSpec = new GetTemplateWithTemplateTypeKeySpec(templateType.TemplateTypeId);
            var templates = await _templateRepository.ListAsync(templateSpec);
            await _templateRepository.DeleteRangeAsync(templates); // you could use soft delete with IsDeleted = true

            var templateTypeDeletedEvent = new TemplateTypeDeletedEvent(templateType, "Mongo-History");
            _messagePublisher.Publish(templateTypeDeletedEvent);

            await _repository.DeleteAsync(templateType);

            return Ok(response);
        }
    }
}