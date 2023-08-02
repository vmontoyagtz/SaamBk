using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnit;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBusinessUnitRequest>.WithActionResult<
        DeleteBusinessUnitResponse>
    {
        private readonly IRepository<Advisor> _advisorRepository;
        private readonly IRepository<BusinessUnitAddress> _businessUnitAddressRepository;
        private readonly IRepository<BusinessUnitCategory> _businessUnitCategoryRepository;
        private readonly IRepository<BusinessUnitDocument> _businessUnitDocumentRepository;
        private readonly IRepository<BusinessUnitEmailAddress> _businessUnitEmailAddressRepository;
        private readonly IRepository<BusinessUnitPhoneNumber> _businessUnitPhoneNumberRepository;
        private readonly IRepository<BusinessUnit> _businessUnitReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnit> _repository;
        private readonly IRepository<TaxInformation> _taxInformationRepository;

        public Delete(IRepository<BusinessUnit> BusinessUnitRepository,
            IRepository<BusinessUnit> BusinessUnitReadRepository,
            IRepository<Advisor> advisorRepository,
            IRepository<BusinessUnitAddress> businessUnitAddressRepository,
            IRepository<BusinessUnitCategory> businessUnitCategoryRepository,
            IRepository<BusinessUnitDocument> businessUnitDocumentRepository,
            IRepository<BusinessUnitEmailAddress> businessUnitEmailAddressRepository,
            IRepository<BusinessUnitPhoneNumber> businessUnitPhoneNumberRepository,
            IRepository<TaxInformation> taxInformationRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BusinessUnitRepository;
            _businessUnitReadRepository = BusinessUnitReadRepository;
            _advisorRepository = advisorRepository;
            _businessUnitAddressRepository = businessUnitAddressRepository;
            _businessUnitCategoryRepository = businessUnitCategoryRepository;
            _businessUnitDocumentRepository = businessUnitDocumentRepository;
            _businessUnitEmailAddressRepository = businessUnitEmailAddressRepository;
            _businessUnitPhoneNumberRepository = businessUnitPhoneNumberRepository;
            _taxInformationRepository = taxInformationRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/businessUnits/{BusinessUnitId}")]
        [SwaggerOperation(
            Summary = "Deletes an BusinessUnit",
            Description = "Deletes an BusinessUnit",
            OperationId = "businessUnits.delete",
            Tags = new[] { "BusinessUnitEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBusinessUnitResponse>> HandleAsync(
            [FromRoute] DeleteBusinessUnitRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBusinessUnitResponse(request.CorrelationId());

            var businessUnit = await _businessUnitReadRepository.GetByIdAsync(request.BusinessUnitId);

            if (businessUnit == null)
            {
                return NotFound();
            }

            var advisorSpec = new GetAdvisorWithBusinessUnitKeySpec(businessUnit.BusinessUnitId);
            var advisors = await _advisorRepository.ListAsync(advisorSpec);
            await _advisorRepository.DeleteRangeAsync(advisors); // you could use soft delete with IsDeleted = true
            var businessUnitAddressSpec =
                new GetBusinessUnitAddressWithBusinessUnitKeySpec(businessUnit.BusinessUnitId);
            var businessUnitAddresses = await _businessUnitAddressRepository.ListAsync(businessUnitAddressSpec);
            await _businessUnitAddressRepository.DeleteRangeAsync(businessUnitAddresses);
            var businessUnitCategorySpec =
                new GetBusinessUnitCategoryWithBusinessUnitKeySpec(businessUnit.BusinessUnitId);
            var businessUnitCategories = await _businessUnitCategoryRepository.ListAsync(businessUnitCategorySpec);
            await _businessUnitCategoryRepository.DeleteRangeAsync(businessUnitCategories);
            var businessUnitDocumentSpec =
                new GetBusinessUnitDocumentWithBusinessUnitKeySpec(businessUnit.BusinessUnitId);
            var businessUnitDocuments = await _businessUnitDocumentRepository.ListAsync(businessUnitDocumentSpec);
            await _businessUnitDocumentRepository.DeleteRangeAsync(businessUnitDocuments);
            var businessUnitEmailAddressSpec =
                new GetBusinessUnitEmailAddressWithBusinessUnitKeySpec(businessUnit.BusinessUnitId);
            var businessUnitEmailAddresses =
                await _businessUnitEmailAddressRepository.ListAsync(businessUnitEmailAddressSpec);
            await _businessUnitEmailAddressRepository.DeleteRangeAsync(businessUnitEmailAddresses);
            var businessUnitPhoneNumberSpec =
                new GetBusinessUnitPhoneNumberWithBusinessUnitKeySpec(businessUnit.BusinessUnitId);
            var businessUnitPhoneNumbers =
                await _businessUnitPhoneNumberRepository.ListAsync(businessUnitPhoneNumberSpec);
            await _businessUnitPhoneNumberRepository.DeleteRangeAsync(businessUnitPhoneNumbers);
            var taxInformationSpec = new GetTaxInformationWithBusinessUnitKeySpec(businessUnit.BusinessUnitId);
            var taxInformations = await _taxInformationRepository.ListAsync(taxInformationSpec);
            await _taxInformationRepository
                .DeleteRangeAsync(taxInformations); // you could use soft delete with IsDeleted = true

            var businessUnitDeletedEvent = new BusinessUnitDeletedEvent(businessUnit, "Mongo-History");
            _messagePublisher.Publish(businessUnitDeletedEvent);

            await _repository.DeleteAsync(businessUnit);

            return Ok(response);
        }
    }
}