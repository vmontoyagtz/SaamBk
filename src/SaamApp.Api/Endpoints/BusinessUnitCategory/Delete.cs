using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.BusinessUnitCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitCategoryEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteBusinessUnitCategoryRequest>.WithActionResult<
        DeleteBusinessUnitCategoryResponse>
    {
        private readonly IRepository<BusinessUnitCategory> _businessUnitCategoryReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitCategory> _repository;

        public Delete(IRepository<BusinessUnitCategory> BusinessUnitCategoryRepository,
            IRepository<BusinessUnitCategory> BusinessUnitCategoryReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = BusinessUnitCategoryRepository;
            _businessUnitCategoryReadRepository = BusinessUnitCategoryReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/businessUnitCategories/{RowId}")]
        [SwaggerOperation(
            Summary = "Deletes an BusinessUnitCategory",
            Description = "Deletes an BusinessUnitCategory",
            OperationId = "businessUnitCategories.delete",
            Tags = new[] { "BusinessUnitCategoryEndpoints" })
        ]
        public override async Task<ActionResult<DeleteBusinessUnitCategoryResponse>> HandleAsync(
            [FromRoute] DeleteBusinessUnitCategoryRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBusinessUnitCategoryResponse(request.CorrelationId());

            var businessUnitCategory = await _businessUnitCategoryReadRepository.GetByIdAsync(request.RowId);

            if (businessUnitCategory == null)
            {
                return NotFound();
            }


            var businessUnitCategoryDeletedEvent =
                new BusinessUnitCategoryDeletedEvent(businessUnitCategory, "Mongo-History");
            _messagePublisher.Publish(businessUnitCategoryDeletedEvent);

            await _repository.DeleteAsync(businessUnitCategory);

            return Ok(response);
        }
    }
}