using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.TaxpayerType;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.TaxpayerTypeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateTaxpayerTypeRequest>.WithActionResult<
        UpdateTaxpayerTypeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<TaxpayerType> _repository;

        public Update(
            IRepository<TaxpayerType> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/taxpayerTypes")]
        [SwaggerOperation(
            Summary = "Updates a TaxpayerType",
            Description = "Updates a TaxpayerType",
            OperationId = "taxpayerTypes.update",
            Tags = new[] { "TaxpayerTypeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateTaxpayerTypeResponse>> HandleAsync(
            UpdateTaxpayerTypeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateTaxpayerTypeResponse(request.CorrelationId());

            var ttatxtToUpdate = _mapper.Map<TaxpayerType>(request);

            var taxpayerTypeToUpdateTest = await _repository.GetByIdAsync(request.TaxpayerTypeId);
            if (taxpayerTypeToUpdateTest is null)
            {
                return NotFound();
            }

            await _repository.UpdateAsync(ttatxtToUpdate);

            var taxpayerTypeUpdatedEvent = new TaxpayerTypeUpdatedEvent(ttatxtToUpdate, "Mongo-History");
            _messagePublisher.Publish(taxpayerTypeUpdatedEvent);

            var dto = _mapper.Map<TaxpayerTypeDto>(ttatxtToUpdate);
            response.TaxpayerType = dto;

            return Ok(response);
        }
    }
}