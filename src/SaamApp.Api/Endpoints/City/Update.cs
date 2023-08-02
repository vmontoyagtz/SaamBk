using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.City;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.CityEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateCityRequest>.WithActionResult<UpdateCityResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<City> _repository;

        public Update(
            IRepository<City> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/cities")]
        [SwaggerOperation(
            Summary = "Updates a City",
            Description = "Updates a City",
            OperationId = "cities.update",
            Tags = new[] { "CityEndpoints" })
        ]
        public override async Task<ActionResult<UpdateCityResponse>> HandleAsync(UpdateCityRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateCityResponse(request.CorrelationId());

            var citToUpdate = _mapper.Map<City>(request);

            var cityToUpdateTest = await _repository.GetByIdAsync(request.CityId);
            if (cityToUpdateTest is null)
            {
                return NotFound();
            }

            citToUpdate.UpdateStateForCity(request.StateId);
            await _repository.UpdateAsync(citToUpdate);

            var cityUpdatedEvent = new CityUpdatedEvent(citToUpdate, "Mongo-History");
            _messagePublisher.Publish(cityUpdatedEvent);

            var dto = _mapper.Map<CityDto>(citToUpdate);
            response.City = dto;

            return Ok(response);
        }
    }
}