using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TaxpayerType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.TaxpayerTypeEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteTaxpayerTypeRequest>.WithActionResult<
        DeleteTaxpayerTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TaxpayerType> _repository;
        private readonly IRepository<TaxInformation> _taxInformationRepository;
        private readonly IRepository<TaxpayerType> _taxpayerTypeReadRepository;

        public Delete(IRepository<TaxpayerType> TaxpayerTypeRepository,
            IRepository<TaxpayerType> TaxpayerTypeReadRepository,
            IRepository<TaxInformation> taxInformationRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = TaxpayerTypeRepository;
            _taxpayerTypeReadRepository = TaxpayerTypeReadRepository;
            _taxInformationRepository = taxInformationRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/taxpayerTypes/{TaxpayerTypeId}")]
        [SwaggerOperation(
            Summary = "Deletes an TaxpayerType",
            Description = "Deletes an TaxpayerType",
            OperationId = "taxpayerTypes.delete",
            Tags = new[] { "TaxpayerTypeEndpoints" })
        ]
        public override async Task<ActionResult<DeleteTaxpayerTypeResponse>> HandleAsync(
            [FromRoute] DeleteTaxpayerTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteTaxpayerTypeResponse(request.CorrelationId());

            var taxpayerType = await _taxpayerTypeReadRepository.GetByIdAsync(request.TaxpayerTypeId);

            if (taxpayerType == null)
            {
                return NotFound();
            }

            var taxInformationSpec = new GetTaxInformationWithTaxpayerTypeKeySpec(taxpayerType.TaxpayerTypeId);
            var taxInformations = await _taxInformationRepository.ListAsync(taxInformationSpec);
            await _taxInformationRepository
                .DeleteRangeAsync(taxInformations); // you could use soft delete with IsDeleted = true

            var taxpayerTypeDeletedEvent = new TaxpayerTypeDeletedEvent(taxpayerType, "Mongo-History");
            _messagePublisher.Publish(taxpayerTypeDeletedEvent);

            await _repository.DeleteAsync(taxpayerType);

            return Ok(response);
        }
    }
}