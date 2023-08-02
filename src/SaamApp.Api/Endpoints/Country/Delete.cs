using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Country;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CountryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCountryRequest>.WithActionResult<
        DeleteCountryResponse>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<Country> _countryReadRepository;
        private readonly IRepository<IdentityDocument> _identityDocumentRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Country> _repository;
        private readonly IRepository<State> _stateRepository;

        public Delete(IRepository<Country> CountryRepository, IRepository<Country> CountryReadRepository,
            IRepository<Address> addressRepository,
            IRepository<IdentityDocument> identityDocumentRepository,
            IRepository<State> stateRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CountryRepository;
            _countryReadRepository = CountryReadRepository;
            _addressRepository = addressRepository;
            _identityDocumentRepository = identityDocumentRepository;
            _stateRepository = stateRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/countries/{CountryId}")]
        [SwaggerOperation(
            Summary = "Deletes an Country",
            Description = "Deletes an Country",
            OperationId = "countries.delete",
            Tags = new[] { "CountryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCountryResponse>> HandleAsync(
            [FromRoute] DeleteCountryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCountryResponse(request.CorrelationId());

            var country = await _countryReadRepository.GetByIdAsync(request.CountryId);

            if (country == null)
            {
                return NotFound();
            }

            var addressSpec = new GetAddressWithCountryKeySpec(country.CountryId);
            var addresses = await _addressRepository.ListAsync(addressSpec);
            await _addressRepository.DeleteRangeAsync(addresses); // you could use soft delete with IsDeleted = true
            var identityDocumentSpec = new GetIdentityDocumentWithCountryKeySpec(country.CountryId);
            var identityDocuments = await _identityDocumentRepository.ListAsync(identityDocumentSpec);
            await _identityDocumentRepository
                .DeleteRangeAsync(identityDocuments); // you could use soft delete with IsDeleted = true
            var stateSpec = new GetStateWithCountryKeySpec(country.CountryId);
            var states = await _stateRepository.ListAsync(stateSpec);
            await _stateRepository.DeleteRangeAsync(states); // you could use soft delete with IsDeleted = true

            var countryDeletedEvent = new CountryDeletedEvent(country, "Mongo-History");
            _messagePublisher.Publish(countryDeletedEvent);

            await _repository.DeleteAsync(country);

            return Ok(response);
        }
    }
}