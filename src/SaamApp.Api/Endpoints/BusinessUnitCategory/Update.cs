using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.BusinessUnitCategoryEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateBusinessUnitCategoryRequest>.WithActionResult<
        UpdateBusinessUnitCategoryResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitCategory> _repository;

        public Update(
            IRepository<BusinessUnitCategory> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/businessUnitCategories")]
        [SwaggerOperation(
            Summary = "Updates a BusinessUnitCategory",
            Description = "Updates a BusinessUnitCategory",
            OperationId = "businessUnitCategories.update",
            Tags = new[] { "BusinessUnitCategoryEndpoints" })
        ]
        public override async Task<ActionResult<UpdateBusinessUnitCategoryResponse>> HandleAsync(
            UpdateBusinessUnitCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBusinessUnitCategoryResponse(request.CorrelationId());

            var bucuucsucToUpdate = _mapper.Map<BusinessUnitCategory>(request);

            var businessUnitCategoryToUpdateTest = await _repository.GetByIdAsync(request.RowId);
            if (businessUnitCategoryToUpdateTest is null)
            {
                return NotFound();
            }

            bucuucsucToUpdate.UpdateRegionAreaAdvisorCategoryForBusinessUnitCategory(
                request.RegionAreaAdvisorCategoryId);
            bucuucsucToUpdate.UpdateBusinessUnitForBusinessUnitCategory(request.BusinessUnitId);
            await _repository.UpdateAsync(bucuucsucToUpdate);

            var businessUnitCategoryUpdatedEvent =
                new BusinessUnitCategoryUpdatedEvent(bucuucsucToUpdate, "Mongo-History");
            _messagePublisher.Publish(businessUnitCategoryUpdatedEvent);

            var dto = _mapper.Map<BusinessUnitCategoryDto>(bucuucsucToUpdate);
            response.BusinessUnitCategory = dto;

            return Ok(response);
        }
    }
}