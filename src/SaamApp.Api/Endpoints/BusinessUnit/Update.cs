using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnit;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BusinessUnitEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBusinessUnitRequest>.WithActionResult<
        UpdateBusinessUnitResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnit> _repository;

        public Update(
            IRepository<BusinessUnit> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/businessUnits")]
        [SwaggerOperation(
            Summary = "Updates a BusinessUnit",
            Description = "Updates a BusinessUnit",
            OperationId = "businessUnits.update",
            Tags = new[] { "BusinessUnitEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBusinessUnitResponse>> HandleAsync(
            UpdateBusinessUnitRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBusinessUnitResponse(request.CorrelationId());

            var buuusuToUpdate = _mapper.Map<BusinessUnit>(request);

            var businessUnitToUpdateTest = await _repository.GetByIdAsync(request.BusinessUnitId);
            if (businessUnitToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(buuusuToUpdate);

            var businessUnitUpdatedEvent = new BusinessUnitUpdatedEvent(buuusuToUpdate, "Mongo-History");
            _messagePublisher.Publish(businessUnitUpdatedEvent);

            var dto = _mapper.Map<BusinessUnitDto>(buuusuToUpdate);
            response.BusinessUnit = dto;

            return Ok(response);
        }
    }
}