using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitAddress;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitAddressEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBusinessUnitAddressRequest>.WithActionResult<
        DeleteBusinessUnitAddressResponse>
    {
        private readonly IRepository<BusinessUnitAddress> _businessUnitAddressReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitAddress> _repository;

        public Delete(IRepository<BusinessUnitAddress> BusinessUnitAddressRepository,
            IRepository<BusinessUnitAddress> BusinessUnitAddressReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BusinessUnitAddressRepository;
            _businessUnitAddressReadRepository = BusinessUnitAddressReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/businessUnitAddresses/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an BusinessUnitAddress",
            Description = "Deletes an BusinessUnitAddress",
            OperationId = "businessUnitAddresses.delete",
            Tags = new[] { "BusinessUnitAddressEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBusinessUnitAddressResponse>> HandleAsync(
            [FromRoute] DeleteBusinessUnitAddressRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBusinessUnitAddressResponse(request.CorrelationId());

            var businessUnitAddress = await _businessUnitAddressReadRepository.GetByIdAsync(request.RowId);

            if (businessUnitAddress == null)
            {
                return NotFound();
            }


            var businessUnitAddressDeletedEvent =
                new BusinessUnitAddressDeletedEvent(businessUnitAddress, "Mongo-History");
            _messagePublisher.Publish(businessUnitAddressDeletedEvent);

            await _repository.DeleteAsync(businessUnitAddress);

            return Ok(response);
        }
    }
}