using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.DiscountCode;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.DiscountCodeEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateDiscountCodeRequest>.WithActionResult<
        UpdateDiscountCodeResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<DiscountCode> _repository;

        public Update(
            IRepository<DiscountCode> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/discountCodes")]
        [SwaggerOperation(
            Summary = "Updates a DiscountCode",
            Description = "Updates a DiscountCode",
            OperationId = "discountCodes.update",
            Tags = new[] { "DiscountCodeEndpoints" })
        ]
        public override async Task<ActionResult<UpdateDiscountCodeResponse>> HandleAsync(
            UpdateDiscountCodeRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateDiscountCodeResponse(request.CorrelationId());

            var dcicscToUpdate = _mapper.Map<DiscountCode>(request);

            var discountCodeToUpdateTest = await _repository.GetByIdAsync(request.DiscountCodeId);
            if (discountCodeToUpdateTest is null)
            {
                return NotFound();
            }

            dcicscToUpdate.UpdateRegionForDiscountCode(request.RegionId);
            await _repository.UpdateAsync(dcicscToUpdate);

            var discountCodeUpdatedEvent = new DiscountCodeUpdatedEvent(dcicscToUpdate, "Mongo-History");
            _messagePublisher.Publish(discountCodeUpdatedEvent);

            var dto = _mapper.Map<DiscountCodeDto>(dcicscToUpdate);
            response.DiscountCode = dto;

            return Ok(response);
        }
    }
}