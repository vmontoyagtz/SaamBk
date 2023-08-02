using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Ardalis.GuardClauses;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel;
using SaamAppLib.SharedKernel.Interfaces;

namespace SaamApp.Domain.Entities
{
    public class RegionAreaAdvisorCategory : BaseEntityEv<Guid>, IAggregateRoot
    {
        private readonly List<AdvisorApplicant> _advisorApplicants = new();

        private readonly List<AiAreaExpertise> _aiAreaExpertises = new();

        private readonly List<AiRobotCategory> _aiRobotCategories = new();

        private readonly List<BusinessUnitCategory> _businessUnitCategories = new();

        private readonly List<Comission> _comissions = new();

        private readonly List<Conversation> _conversations = new();

        private readonly List<Message> _messages = new();

        private readonly List<ProductCategory> _productCategories = new();

        private readonly List<TemplateCategory> _templateCategories = new();

        private readonly List<UnansweredConversation> _unansweredConversations = new();

        private RegionAreaAdvisorCategory() { } // EF required

        //[SetsRequiredMembers]
        public RegionAreaAdvisorCategory(Guid regionAreaAdvisorCategoryId, Guid advisorId, Guid areaId, Guid categoryId,
            Guid regionId)
        {
            RegionAreaAdvisorCategoryId =
                Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            AdvisorId = Guard.Against.NullOrEmpty(advisorId, nameof(advisorId));
            AreaId = Guard.Against.NullOrEmpty(areaId, nameof(areaId));
            CategoryId = Guard.Against.NullOrEmpty(categoryId, nameof(categoryId));
            RegionId = Guard.Against.NullOrEmpty(regionId, nameof(regionId));
        }

        [Key] public Guid RegionAreaAdvisorCategoryId { get; private set; }

        public virtual Advisor Advisor { get; private set; }

        public Guid AdvisorId { get; private set; }

        public virtual Area Area { get; private set; }

        public Guid AreaId { get; private set; }

        public virtual Category Category { get; private set; }

        public Guid CategoryId { get; private set; }

        public virtual Region Region { get; private set; }

        public Guid RegionId { get; private set; }
        public IEnumerable<AdvisorApplicant> AdvisorApplicants => _advisorApplicants.AsReadOnly();
        public IEnumerable<AiAreaExpertise> AiAreaExpertises => _aiAreaExpertises.AsReadOnly();
        public IEnumerable<AiRobotCategory> AiRobotCategories => _aiRobotCategories.AsReadOnly();
        public IEnumerable<BusinessUnitCategory> BusinessUnitCategories => _businessUnitCategories.AsReadOnly();
        public IEnumerable<Comission> Comissions => _comissions.AsReadOnly();
        public IEnumerable<Conversation> Conversations => _conversations.AsReadOnly();
        public IEnumerable<Message> Messages => _messages.AsReadOnly();
        public IEnumerable<ProductCategory> ProductCategories => _productCategories.AsReadOnly();
        public IEnumerable<TemplateCategory> TemplateCategories => _templateCategories.AsReadOnly();
        public IEnumerable<UnansweredConversation> UnansweredConversations => _unansweredConversations.AsReadOnly();


        public void UpdateAreaForRegionAreaAdvisorCategory(Guid newAreaId)
        {
            Guard.Against.NullOrEmpty(newAreaId, nameof(newAreaId));
            if (newAreaId == AreaId)
            {
                return;
            }

            AreaId = newAreaId;
            var regionAreaAdvisorCategoryUpdatedEvent =
                new RegionAreaAdvisorCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(regionAreaAdvisorCategoryUpdatedEvent);
        }


        public void UpdateCategoryForRegionAreaAdvisorCategory(Guid newCategoryId)
        {
            Guard.Against.NullOrEmpty(newCategoryId, nameof(newCategoryId));
            if (newCategoryId == CategoryId)
            {
                return;
            }

            CategoryId = newCategoryId;
            var regionAreaAdvisorCategoryUpdatedEvent =
                new RegionAreaAdvisorCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(regionAreaAdvisorCategoryUpdatedEvent);
        }


        public void UpdateRegionForRegionAreaAdvisorCategory(Guid newRegionId)
        {
            Guard.Against.NullOrEmpty(newRegionId, nameof(newRegionId));
            if (newRegionId == RegionId)
            {
                return;
            }

            RegionId = newRegionId;
            var regionAreaAdvisorCategoryUpdatedEvent =
                new RegionAreaAdvisorCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(regionAreaAdvisorCategoryUpdatedEvent);
        }


        public void UpdateAdvisorForRegionAreaAdvisorCategory(Guid newAdvisorId)
        {
            Guard.Against.NullOrEmpty(newAdvisorId, nameof(newAdvisorId));
            if (newAdvisorId == AdvisorId)
            {
                return;
            }

            AdvisorId = newAdvisorId;
            var regionAreaAdvisorCategoryUpdatedEvent =
                new RegionAreaAdvisorCategoryUpdatedEvent(this, "Mongo-History");
            Events.Add(regionAreaAdvisorCategoryUpdatedEvent);
        }


        public void AddNewAdvisorApplicant(AdvisorApplicant advisorApplicant)
        {
            Guard.Against.Null(advisorApplicant, nameof(advisorApplicant));
            Guard.Against.NullOrEmpty(advisorApplicant.AdvisorApplicantId, nameof(advisorApplicant.AdvisorApplicantId));
            Guard.Against.DuplicateAdvisorApplicant(_advisorApplicants, advisorApplicant, nameof(advisorApplicant));
            _advisorApplicants.Add(advisorApplicant);
            var advisorApplicantAddedEvent = new AdvisorApplicantCreatedEvent(advisorApplicant, "Mongo-History");
            Events.Add(advisorApplicantAddedEvent);
        }

        public void DeleteAdvisorApplicant(AdvisorApplicant advisorApplicant)
        {
            Guard.Against.Null(advisorApplicant, nameof(advisorApplicant));
            var advisorApplicantToDelete = _advisorApplicants
                .Where(aa => aa.AdvisorApplicantId == advisorApplicant.AdvisorApplicantId)
                .FirstOrDefault();
            if (advisorApplicantToDelete != null)
            {
                _advisorApplicants.Remove(advisorApplicantToDelete);
                var advisorApplicantDeletedEvent =
                    new AdvisorApplicantDeletedEvent(advisorApplicantToDelete, "Mongo-History");
                Events.Add(advisorApplicantDeletedEvent);
            }
        }

        public void AddNewAiAreaExpertise(Guid modelId, Guid regionAreaAdvisorCategoryId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var newAiAreaExpertise = new AiAreaExpertise(regionAreaAdvisorCategoryId, modelId, tenantId);
            Guard.Against.DuplicateAiAreaExpertise(_aiAreaExpertises, newAiAreaExpertise, nameof(newAiAreaExpertise));
            _aiAreaExpertises.Add(newAiAreaExpertise);
            var aiAreaExpertiseAddedEvent = new AiAreaExpertiseCreatedEvent(newAiAreaExpertise, "Mongo-History");
            Events.Add(aiAreaExpertiseAddedEvent);
        }

        public void DeleteAiAreaExpertise(Guid modelId, Guid regionAreaAdvisorCategoryId, Guid tenantId)
        {
            Guard.Against.NullOrEmpty(modelId, nameof(modelId));
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var aiAreaExpertiseToDelete = _aiAreaExpertises
                .Where(aae1 => aae1.ModelId == modelId)
                .Where(aae2 => aae2.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(aae3 => aae3.TenantId == tenantId)
                .FirstOrDefault();

            if (aiAreaExpertiseToDelete != null)
            {
                _aiAreaExpertises.Remove(aiAreaExpertiseToDelete);
                var aiAreaExpertiseDeletedEvent =
                    new AiAreaExpertiseDeletedEvent(aiAreaExpertiseToDelete, "Mongo-History");
                Events.Add(aiAreaExpertiseDeletedEvent);
            }
        }

        public void AddNewAiRobotCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));

            var newAiRobotCategory = new AiRobotCategory(aiRobotId, comissionId, regionAreaAdvisorCategoryId);
            Guard.Against.DuplicateAiRobotCategory(_aiRobotCategories, newAiRobotCategory, nameof(newAiRobotCategory));
            _aiRobotCategories.Add(newAiRobotCategory);
            var aiRobotCategoryAddedEvent = new AiRobotCategoryCreatedEvent(newAiRobotCategory, "Mongo-History");
            Events.Add(aiRobotCategoryAddedEvent);
        }

        public void DeleteAiRobotCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid aiRobotId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(aiRobotId, nameof(aiRobotId));

            var aiRobotCategoryToDelete = _aiRobotCategories
                .Where(arc1 => arc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(arc2 => arc2.ComissionId == comissionId)
                .Where(arc3 => arc3.AiRobotId == aiRobotId)
                .FirstOrDefault();

            if (aiRobotCategoryToDelete != null)
            {
                _aiRobotCategories.Remove(aiRobotCategoryToDelete);
                var aiRobotCategoryDeletedEvent =
                    new AiRobotCategoryDeletedEvent(aiRobotCategoryToDelete, "Mongo-History");
                Events.Add(aiRobotCategoryDeletedEvent);
            }
        }

        public void AddNewBusinessUnitCategory(Guid regionAreaAdvisorCategoryId, Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));

            var newBusinessUnitCategory = new BusinessUnitCategory(businessUnitId, regionAreaAdvisorCategoryId);
            Guard.Against.DuplicateBusinessUnitCategory(_businessUnitCategories, newBusinessUnitCategory,
                nameof(newBusinessUnitCategory));
            _businessUnitCategories.Add(newBusinessUnitCategory);
            var businessUnitCategoryAddedEvent =
                new BusinessUnitCategoryCreatedEvent(newBusinessUnitCategory, "Mongo-History");
            Events.Add(businessUnitCategoryAddedEvent);
        }

        public void DeleteBusinessUnitCategory(Guid regionAreaAdvisorCategoryId, Guid businessUnitId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(businessUnitId, nameof(businessUnitId));

            var businessUnitCategoryToDelete = _businessUnitCategories
                .Where(buc1 => buc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(buc2 => buc2.BusinessUnitId == businessUnitId)
                .FirstOrDefault();

            if (businessUnitCategoryToDelete != null)
            {
                _businessUnitCategories.Remove(businessUnitCategoryToDelete);
                var businessUnitCategoryDeletedEvent =
                    new BusinessUnitCategoryDeletedEvent(businessUnitCategoryToDelete, "Mongo-History");
                Events.Add(businessUnitCategoryDeletedEvent);
            }
        }

        public void AddNewComission(Comission comission)
        {
            Guard.Against.Null(comission, nameof(comission));
            Guard.Against.NullOrEmpty(comission.ComissionId, nameof(comission.ComissionId));
            Guard.Against.DuplicateComission(_comissions, comission, nameof(comission));
            _comissions.Add(comission);
            var comissionAddedEvent = new ComissionCreatedEvent(comission, "Mongo-History");
            Events.Add(comissionAddedEvent);
        }

        public void DeleteComission(Comission comission)
        {
            Guard.Against.Null(comission, nameof(comission));
            var comissionToDelete = _comissions
                .Where(c => c.ComissionId == comission.ComissionId)
                .FirstOrDefault();
            if (comissionToDelete != null)
            {
                _comissions.Remove(comissionToDelete);
                var comissionDeletedEvent = new ComissionDeletedEvent(comissionToDelete, "Mongo-History");
                Events.Add(comissionDeletedEvent);
            }
        }

        public void AddNewConversation(Conversation conversation)
        {
            Guard.Against.Null(conversation, nameof(conversation));
            Guard.Against.NullOrEmpty(conversation.ConversationId, nameof(conversation.ConversationId));
            Guard.Against.DuplicateConversation(_conversations, conversation, nameof(conversation));
            _conversations.Add(conversation);
            var conversationAddedEvent = new ConversationCreatedEvent(conversation, "Mongo-History");
            Events.Add(conversationAddedEvent);
        }

        public void DeleteConversation(Conversation conversation)
        {
            Guard.Against.Null(conversation, nameof(conversation));
            var conversationToDelete = _conversations
                .Where(c => c.ConversationId == conversation.ConversationId)
                .FirstOrDefault();
            if (conversationToDelete != null)
            {
                _conversations.Remove(conversationToDelete);
                var conversationDeletedEvent = new ConversationDeletedEvent(conversationToDelete, "Mongo-History");
                Events.Add(conversationDeletedEvent);
            }
        }

        public void AddNewMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            Guard.Against.NullOrEmpty(message.MessageId, nameof(message.MessageId));
            Guard.Against.DuplicateMessage(_messages, message, nameof(message));
            _messages.Add(message);
            var messageAddedEvent = new MessageCreatedEvent(message, "Mongo-History");
            Events.Add(messageAddedEvent);
        }

        public void DeleteMessage(Message message)
        {
            Guard.Against.Null(message, nameof(message));
            var messageToDelete = _messages
                .Where(m => m.MessageId == message.MessageId)
                .FirstOrDefault();
            if (messageToDelete != null)
            {
                _messages.Remove(messageToDelete);
                var messageDeletedEvent = new MessageDeletedEvent(messageToDelete, "Mongo-History");
                Events.Add(messageDeletedEvent);
            }
        }

        public void AddNewProductCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid productId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var newProductCategory = new ProductCategory(comissionId, productId, regionAreaAdvisorCategoryId, tenantId);
            Guard.Against.DuplicateProductCategory(_productCategories, newProductCategory, nameof(newProductCategory));
            _productCategories.Add(newProductCategory);
            var productCategoryAddedEvent = new ProductCategoryCreatedEvent(newProductCategory, "Mongo-History");
            Events.Add(productCategoryAddedEvent);
        }

        public void DeleteProductCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid productId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(productId, nameof(productId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var productCategoryToDelete = _productCategories
                .Where(pc1 => pc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(pc2 => pc2.ComissionId == comissionId)
                .Where(pc3 => pc3.ProductId == productId)
                .Where(pc4 => pc4.TenantId == tenantId)
                .FirstOrDefault();

            if (productCategoryToDelete != null)
            {
                _productCategories.Remove(productCategoryToDelete);
                var productCategoryDeletedEvent =
                    new ProductCategoryDeletedEvent(productCategoryToDelete, "Mongo-History");
                Events.Add(productCategoryDeletedEvent);
            }
        }

        public void AddNewTemplateCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid templateId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var newTemplateCategory =
                new TemplateCategory(comissionId, regionAreaAdvisorCategoryId, templateId, tenantId);
            Guard.Against.DuplicateTemplateCategory(_templateCategories, newTemplateCategory,
                nameof(newTemplateCategory));
            _templateCategories.Add(newTemplateCategory);
            var templateCategoryAddedEvent = new TemplateCategoryCreatedEvent(newTemplateCategory, "Mongo-History");
            Events.Add(templateCategoryAddedEvent);
        }

        public void DeleteTemplateCategory(Guid regionAreaAdvisorCategoryId, Guid comissionId, Guid templateId,
            Guid tenantId)
        {
            Guard.Against.NullOrEmpty(regionAreaAdvisorCategoryId, nameof(regionAreaAdvisorCategoryId));
            Guard.Against.NullOrEmpty(comissionId, nameof(comissionId));
            Guard.Against.NullOrEmpty(templateId, nameof(templateId));
            Guard.Against.NullOrEmpty(tenantId, nameof(tenantId));

            var templateCategoryToDelete = _templateCategories
                .Where(tc1 => tc1.RegionAreaAdvisorCategoryId == regionAreaAdvisorCategoryId)
                .Where(tc2 => tc2.ComissionId == comissionId)
                .Where(tc3 => tc3.TemplateId == templateId)
                .Where(tc4 => tc4.TenantId == tenantId)
                .FirstOrDefault();

            if (templateCategoryToDelete != null)
            {
                _templateCategories.Remove(templateCategoryToDelete);
                var templateCategoryDeletedEvent =
                    new TemplateCategoryDeletedEvent(templateCategoryToDelete, "Mongo-History");
                Events.Add(templateCategoryDeletedEvent);
            }
        }

        public void AddNewUnansweredConversation(UnansweredConversation unansweredConversation)
        {
            Guard.Against.Null(unansweredConversation, nameof(unansweredConversation));
            Guard.Against.NullOrEmpty(unansweredConversation.UnansweredConversationId,
                nameof(unansweredConversation.UnansweredConversationId));
            Guard.Against.DuplicateUnansweredConversation(_unansweredConversations, unansweredConversation,
                nameof(unansweredConversation));
            _unansweredConversations.Add(unansweredConversation);
            var unansweredConversationAddedEvent =
                new UnansweredConversationCreatedEvent(unansweredConversation, "Mongo-History");
            Events.Add(unansweredConversationAddedEvent);
        }

        public void DeleteUnansweredConversation(UnansweredConversation unansweredConversation)
        {
            Guard.Against.Null(unansweredConversation, nameof(unansweredConversation));
            var unansweredConversationToDelete = _unansweredConversations
                .Where(uc => uc.UnansweredConversationId == unansweredConversation.UnansweredConversationId)
                .FirstOrDefault();
            if (unansweredConversationToDelete != null)
            {
                _unansweredConversations.Remove(unansweredConversationToDelete);
                var unansweredConversationDeletedEvent =
                    new UnansweredConversationDeletedEvent(unansweredConversationToDelete, "Mongo-History");
                Events.Add(unansweredConversationDeletedEvent);
            }
        }
    }
}