using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TaxInformation;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TaxInformationEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTaxInformationRequest>.WithActionResult<
        UpdateTaxInformationResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TaxInformation> _repository;

        public Update(
            IRepository<TaxInformation> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/taxInformations")]
        [SwaggerOperation(
            Summary = "Updates a TaxInformation",
            Description = "Updates a TaxInformation",
            OperationId = "taxInformations.update",
            Tags = new[] { "TaxInformationEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTaxInformationResponse>> HandleAsync(
            UpdateTaxInformationRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTaxInformationResponse(request.CorrelationId());

            var tiaixiToUpdate = _mapper.Map<TaxInformation>(request);

            var taxInformationToUpdateTest = await _repository.GetByIdAsync(request.TaxInformationId);
            if (taxInformationToUpdateTest is null)
            {
                return NotFound();
            }

            tiaixiToUpdate.UpdateBusinessUnitForTaxInformation(request.BusinessUnitId);
            tiaixiToUpdate.UpdateTaxpayerTypeForTaxInformation(request.TaxpayerTypeId);
            await _repository.UpdateAsync(tiaixiToUpdate);

            var taxInformationUpdatedEvent = new TaxInformationUpdatedEvent(tiaixiToUpdate, "Mongo-History");
            _messagePublisher.Publish(taxInformationUpdatedEvent);

            var dto = _mapper.Map<TaxInformationDto>(tiaixiToUpdate);
            response.TaxInformation = dto;

            return Ok(response);
        }
    }
}