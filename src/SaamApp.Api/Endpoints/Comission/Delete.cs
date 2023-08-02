using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Comission;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.ComissionEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteComissionRequest>.WithActionResult<
        DeleteComissionResponse>
    {
        private readonly IRepository<AiRobotCategory> _aiRobotCategoryRepository;
        private readonly IRepository<Comission> _comissionReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<Comission> _repository;
        private readonly IRepository<TemplateCategory> _templateCategoryRepository;

        public Delete(IRepository<Comission> ComissionRepository, IRepository<Comission> ComissionReadRepository,
            IRepository<AiRobotCategory> aiRobotCategoryRepository,
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<TemplateCategory> templateCategoryRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = ComissionRepository;
            _comissionReadRepository = ComissionReadRepository;
            _aiRobotCategoryRepository = aiRobotCategoryRepository;
            _productCategoryRepository = productCategoryRepository;
            _templateCategoryRepository = templateCategoryRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/comissions/{ComissionId}")]
        [SwaggerOperation(
            Summary = "Deletes an Comission",
            Description = "Deletes an Comission",
            OperationId = "comissions.delete",
            Tags = new[] { "ComissionEndpoints" })
        ]
        public override async Task<ActionResult<DeleteComissionResponse>> HandleAsync(
            [FromRoute] DeleteComissionRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteComissionResponse(request.CorrelationId());

            var comission = await _comissionReadRepository.GetByIdAsync(request.ComissionId);

            if (comission == null)
            {
                return NotFound();
            }

            var aiRobotCategorySpec = new GetAiRobotCategoryWithComissionKeySpec(comission.ComissionId);
            var aiRobotCategories = await _aiRobotCategoryRepository.ListAsync(aiRobotCategorySpec);
            await _aiRobotCategoryRepository.DeleteRangeAsync(aiRobotCategories);
            var productCategorySpec = new GetProductCategoryWithComissionKeySpec(comission.ComissionId);
            var productCategories = await _productCategoryRepository.ListAsync(productCategorySpec);
            await _productCategoryRepository.DeleteRangeAsync(productCategories);
            var templateCategorySpec = new GetTemplateCategoryWithComissionKeySpec(comission.ComissionId);
            var templateCategories = await _templateCategoryRepository.ListAsync(templateCategorySpec);
            await _templateCategoryRepository.DeleteRangeAsync(templateCategories);

            var comissionDeletedEvent = new ComissionDeletedEvent(comission, "Mongo-History");
            _messagePublisher.Publish(comissionDeletedEvent);

            await _repository.DeleteAsync(comission);

            return Ok(response);
        }
    }
}