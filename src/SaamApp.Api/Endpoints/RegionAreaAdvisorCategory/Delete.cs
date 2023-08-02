using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.RegionAreaAdvisorCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.RegionAreaAdvisorCategoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteRegionAreaAdvisorCategoryRequest>.WithActionResult<
        DeleteRegionAreaAdvisorCategoryResponse>
    {
        private readonly IRepository<AdvisorApplicant> _advisorApplicantRepository;
        private readonly IRepository<AiAreaExpertise> _aiAreaExpertiseRepository;
        private readonly IRepository<AiRobotCategory> _aiRobotCategoryRepository;
        private readonly IRepository<BusinessUnitCategory> _businessUnitCategoryRepository;
        private readonly IRepository<Comission> _comissionRepository;
        private readonly IRepository<Conversation> _conversationRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Message> _messageRepository;
        private readonly IRepository<ProductCategory> _productCategoryRepository;
        private readonly IRepository<RegionAreaAdvisorCategory> _regionAreaAdvisorCategoryReadRepository;
        private readonly IRepository<RegionAreaAdvisorCategory> _repository;
        private readonly IRepository<TemplateCategory> _templateCategoryRepository;
        private readonly IRepository<UnansweredConversation> _unansweredConversationRepository;

        public Delete(IRepository<RegionAreaAdvisorCategory> RegionAreaAdvisorCategoryRepository,
            IRepository<RegionAreaAdvisorCategory> RegionAreaAdvisorCategoryReadRepository,
            IRepository<AdvisorApplicant> advisorApplicantRepository,
            IRepository<AiAreaExpertise> aiAreaExpertiseRepository,
            IRepository<AiRobotCategory> aiRobotCategoryRepository,
            IRepository<BusinessUnitCategory> businessUnitCategoryRepository,
            IRepository<Comission> comissionRepository,
            IRepository<Conversation> conversationRepository,
            IRepository<Message> messageRepository,
            IRepository<ProductCategory> productCategoryRepository,
            IRepository<TemplateCategory> templateCategoryRepository,
            IRepository<UnansweredConversation> unansweredConversationRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = RegionAreaAdvisorCategoryRepository;
            _regionAreaAdvisorCategoryReadRepository = RegionAreaAdvisorCategoryReadRepository;
            _advisorApplicantRepository = advisorApplicantRepository;
            _aiAreaExpertiseRepository = aiAreaExpertiseRepository;
            _aiRobotCategoryRepository = aiRobotCategoryRepository;
            _businessUnitCategoryRepository = businessUnitCategoryRepository;
            _comissionRepository = comissionRepository;
            _conversationRepository = conversationRepository;
            _messageRepository = messageRepository;
            _productCategoryRepository = productCategoryRepository;
            _templateCategoryRepository = templateCategoryRepository;
            _unansweredConversationRepository = unansweredConversationRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/regionAreaAdvisorCategories/{RegionAreaAdvisorCategoryId}")]
        [SwaggerOperation(
            Summary = "Deletes an RegionAreaAdvisorCategory",
            Description = "Deletes an RegionAreaAdvisorCategory",
            OperationId = "regionAreaAdvisorCategories.delete",
            Tags = new[] { "RegionAreaAdvisorCategoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteRegionAreaAdvisorCategoryResponse>> HandleAsync(
            [FromRoute] DeleteRegionAreaAdvisorCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteRegionAreaAdvisorCategoryResponse(request.CorrelationId());

            var regionAreaAdvisorCategory =
                await _regionAreaAdvisorCategoryReadRepository.GetByIdAsync(request.RegionAreaAdvisorCategoryId);

            if (regionAreaAdvisorCategory == null)
            {
                return NotFound();
            }

            var advisorApplicantSpec =
                new GetAdvisorApplicantWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var advisorApplicants = await _advisorApplicantRepository.ListAsync(advisorApplicantSpec);
            await _advisorApplicantRepository
                .DeleteRangeAsync(advisorApplicants); // you could use soft delete with IsDeleted = true
            var aiAreaExpertiseSpec =
                new GetAiAreaExpertiseWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var aiAreaExpertises = await _aiAreaExpertiseRepository.ListAsync(aiAreaExpertiseSpec);
            await _aiAreaExpertiseRepository.DeleteRangeAsync(aiAreaExpertises);
            var aiRobotCategorySpec =
                new GetAiRobotCategoryWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var aiRobotCategories = await _aiRobotCategoryRepository.ListAsync(aiRobotCategorySpec);
            await _aiRobotCategoryRepository.DeleteRangeAsync(aiRobotCategories);
            var businessUnitCategorySpec =
                new GetBusinessUnitCategoryWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var businessUnitCategories = await _businessUnitCategoryRepository.ListAsync(businessUnitCategorySpec);
            await _businessUnitCategoryRepository.DeleteRangeAsync(businessUnitCategories);
            var comissionSpec =
                new GetComissionWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var comissions = await _comissionRepository.ListAsync(comissionSpec);
            await _comissionRepository.DeleteRangeAsync(comissions); // you could use soft delete with IsDeleted = true
            var conversationSpec =
                new GetConversationWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var conversations = await _conversationRepository.ListAsync(conversationSpec);
            await _conversationRepository
                .DeleteRangeAsync(conversations); // you could use soft delete with IsDeleted = true
            var messageSpec =
                new GetMessageWithRegionAreaAdvisorCategoryKeySpec(
                    regionAreaAdvisorCategory.RegionAreaAdvisorCategoryId);
            var messages = await _messageRepository.ListAsync(messageSpec);
            await _messageRepository.DeleteRangeAsync(messages); // you could use soft delete with IsDeleted = true
            var productCategorySpec =
                new GetProductCategoryWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var productCategories = await _productCategoryRepository.ListAsync(productCategorySpec);
            await _productCategoryRepository.DeleteRangeAsync(productCategories);
            var templateCategorySpec =
                new GetTemplateCategoryWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var templateCategories = await _templateCategoryRepository.ListAsync(templateCategorySpec);
            await _templateCategoryRepository.DeleteRangeAsync(templateCategories);
            var unansweredConversationSpec =
                new GetUnansweredConversationWithRegionAreaAdvisorCategoryKeySpec(regionAreaAdvisorCategory
                    .RegionAreaAdvisorCategoryId);
            var unansweredConversations = await _unansweredConversationRepository.ListAsync(unansweredConversationSpec);
            await _unansweredConversationRepository
                .DeleteRangeAsync(unansweredConversations); // you could use soft delete with IsDeleted = true

            var regionAreaAdvisorCategoryDeletedEvent =
                new RegionAreaAdvisorCategoryDeletedEvent(regionAreaAdvisorCategory, "Mongo-History");
            _messagePublisher.Publish(regionAreaAdvisorCategoryDeletedEvent);

            await _repository.DeleteAsync(regionAreaAdvisorCategory);

            return Ok(response);
        }
    }
}