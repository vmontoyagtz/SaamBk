using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBusinessUnitTypeRequest>.WithActionResult<
        DeleteBusinessUnitTypeResponse>
    {
        private readonly IRepository<BusinessUnitType> _businessUnitTypeReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitType> _repository;

        public Delete(IRepository<BusinessUnitType> BusinessUnitTypeRepository,
            IRepository<BusinessUnitType> BusinessUnitTypeReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BusinessUnitTypeRepository;
            _businessUnitTypeReadRepository = BusinessUnitTypeReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/businessUnitTypes/{BusinessUnitTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an BusinessUnitType",
            Description = "Deletes an BusinessUnitType",
            OperationId = "businessUnitTypes.delete",
            Tags = new[] { "BusinessUnitTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBusinessUnitTypeResponse>> HandleAsync(
            [FromRoute] DeleteBusinessUnitTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBusinessUnitTypeResponse(request.CorrelationId());

            var businessUnitType = await _businessUnitTypeReadRepository.GetByIdAsync(request.BusinessUnitTypeId);

            if (businessUnitType == null)
            {
                return NotFound();
            }


            var businessUnitTypeDeletedEvent = new BusinessUnitTypeDeletedEvent(businessUnitType, "Mongo-History");
            _messagePublisher.Publish(businessUnitTypeDeletedEvent);

            await _repository.DeleteAsync(businessUnitType);

            return Ok(response);
        }
    }
}