using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.City;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CityEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteCityRequest>.WithActionResult<
        DeleteCityResponse>
    {
        private readonly IRepository<Address> _addressRepository;
        private readonly IRepository<City> _cityReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<City> _repository;

        public Delete(IRepository<City> CityRepository, IRepository<City> CityReadRepository,
            IRepository<Address> addressRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = CityRepository;
            _cityReadRepository = CityReadRepository;
            _addressRepository = addressRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/cities/{CityId}")]
        [SwaggerOperation(
            Summary = "Deletes an City",
            Description = "Deletes an City",
            OperationId = "cities.delete",
            Tags = new[] { "CityEndpoints" })
        ]
        public override async Task<ActionResult<DeleteCityResponse>> HandleAsync(
            [FromRoute] DeleteCityRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteCityResponse(request.CorrelationId());

            var city = await _cityReadRepository.GetByIdAsync(request.CityId);

            if (city == null)
            {
                return NotFound();
            }

            var addressSpec = new GetAddressWithCityKeySpec(city.CityId);
            var addresses = await _addressRepository.ListAsync(addressSpec);
            await _addressRepository.DeleteRangeAsync(addresses); // you could use soft delete with IsDeleted = true

            var cityDeletedEvent = new CityDeletedEvent(city, "Mongo-History");
            _messagePublisher.Publish(cityDeletedEvent);

            await _repository.DeleteAsync(city);

            return Ok(response);
        }
    }
}