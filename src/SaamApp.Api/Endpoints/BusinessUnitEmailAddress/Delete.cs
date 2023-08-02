using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitEmailAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitEmailAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBusinessUnitEmailAddressRequest>.WithActionResult<
        DeleteBusinessUnitEmailAddressResponse>
    {
        private readonly IRepository<BusinessUnitEmailAddress> _businessUnitEmailAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitEmailAddress> _repository;

        public Delete(IRepository<BusinessUnitEmailAddress> BusinessUnitEmailAddressRepository,
            IRepository<BusinessUnitEmailAddress> BusinessUnitEmailAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BusinessUnitEmailAddressRepository;
            _businessUnitEmailAddressReadRepository = BusinessUnitEmailAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/businessUnitEmailAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an BusinessUnitEmailAddress",
            Description = "Deletes an BusinessUnitEmailAddress",
            OperationId = "businessUnitEmailAddresses.delete",
            Tags = new[] { "BusinessUnitEmailAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBusinessUnitEmailAddressResponse>> HandleAsync(
            [FromRoute] DeleteBusinessUnitEmailAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBusinessUnitEmailAddressResponse(request.CorrelationId());

            var businessUnitEmailAddress = await _businessUnitEmailAddressReadRepository.GetByIdAsync(request.RowId);

            if (businessUnitEmailAddress == null)
            {
                return NotFound();
            }


            var businessUnitEmailAddressDeletedEvent =
                new BusinessUnitEmailAddressDeletedEvent(businessUnitEmailAddress, "Mongo-History");
            _messagePublisher.Publish(businessUnitEmailAddressDeletedEvent);

            await _repository.DeleteAsync(businessUnitEmailAddress);

            return Ok(response);
        }
    }
}