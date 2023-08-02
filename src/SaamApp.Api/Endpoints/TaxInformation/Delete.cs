using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TaxInformation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TaxInformationEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTaxInformationRequest>.WithActionResult<
        DeleteTaxInformationResponse>
    {
        private readonly IRepository<Account> _accountRepository;
        private readonly IRepository<Advisor> _advisorRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TaxInformation> _repository;
        private readonly IRepository<TaxInformation> _taxInformationReadRepository;

        public Delete(IRepository<TaxInformation> TaxInformationRepository,
            IRepository<TaxInformation> TaxInformationReadRepository,
            IRepository<Account> accountRepository,
            IRepository<Advisor> advisorRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TaxInformationRepository;
            _taxInformationReadRepository = TaxInformationReadRepository;
            _accountRepository = accountRepository;
            _advisorRepository = advisorRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/taxInformations/{TaxInformationId}")]
        [SwaggerOperation(
            Summary = "Deletes an TaxInformation",
            Description = "Deletes an TaxInformation",
            OperationId = "taxInformations.delete",
            Tags = new[] { "TaxInformationEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTaxInformationResponse>> HandleAsync(
            [FromRoute] DeleteTaxInformationRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTaxInformationResponse(request.CorrelationId());

            var taxInformation = await _taxInformationReadRepository.GetByIdAsync(request.TaxInformationId);

            if (taxInformation == null)
            {
                return NotFound();
            }

            var accountSpec = new GetAccountWithTaxInformationKeySpec(taxInformation.TaxInformationId);
            var accounts = await _accountRepository.ListAsync(accountSpec);
            await _accountRepository.DeleteRangeAsync(accounts); // you could use soft delete with IsDeleted = true
            var advisorSpec = new GetAdvisorWithTaxInformationKeySpec(taxInformation.TaxInformationId);
            var advisors = await _advisorRepository.ListAsync(advisorSpec);
            await _advisorRepository.DeleteRangeAsync(advisors); // you could use soft delete with IsDeleted = true

            var taxInformationDeletedEvent = new TaxInformationDeletedEvent(taxInformation, "Mongo-History");
            _messagePublisher.Publish(taxInformationDeletedEvent);

            await _repository.DeleteAsync(taxInformation);

            return Ok(response);
        }
    }
}