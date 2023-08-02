using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BusinessUnitTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBusinessUnitTypeRequest>.WithActionResult<
        UpdateBusinessUnitTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitType> _repository;

        public Update(
            IRepository<BusinessUnitType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/businessUnitTypes")]
        [SwaggerOperation(
            Summary = "Updates a BusinessUnitType",
            Description = "Updates a BusinessUnitType",
            OperationId = "businessUnitTypes.update",
            Tags = new[] { "BusinessUnitTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBusinessUnitTypeResponse>> HandleAsync(
            UpdateBusinessUnitTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBusinessUnitTypeResponse(request.CorrelationId());

            var butuutsutToUpdate = _mapper.Map<BusinessUnitType>(request);

            var businessUnitTypeToUpdateTest = await _repository.GetByIdAsync(request.BusinessUnitTypeId);
            if (businessUnitTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(butuutsutToUpdate);

            var businessUnitTypeUpdatedEvent = new BusinessUnitTypeUpdatedEvent(butuutsutToUpdate, "Mongo-History");
            _messagePublisher.Publish(businessUnitTypeUpdatedEvent);

            var dto = _mapper.Map<BusinessUnitTypeDto>(butuutsutToUpdate);
            response.BusinessUnitType = dto;

            return Ok(response);
        }
    }
}