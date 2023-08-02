using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Country;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CountryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCountryRequest>.WithActionResult<UpdateCountryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Country> _repository;

        public Update(
            IRepository<Country> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/countries")]
        [SwaggerOperation(
            Summary = "Updates a Country",
            Description = "Updates a Country",
            OperationId = "countries.update",
            Tags = new[] { "CountryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCountryResponse>> HandleAsync(UpdateCountryRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateCountryResponse(request.CorrelationId());

            var couToUpdate = _mapper.Map<Country>(request);

            var countryToUpdateTest = await _repository.GetByIdAsync(request.CountryId);
            if (countryToUpdateTest is null)
            {
                return NotFound();
            }

            couToUpdate.UpdateRegionForCountry(request.RegionId);
            await _repository.UpdateAsync(couToUpdate);

            var countryUpdatedEvent = new CountryUpdatedEvent(couToUpdate, "Mongo-History");
            _messagePublisher.Publish(countryUpdatedEvent);

            var dto = _mapper.Map<CountryDto>(couToUpdate);
            response.Country = dto;

            return Ok(response);
        }
    }
}