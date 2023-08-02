using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.BusinessUnitCategory;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.BusinessUnitCategoryEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateBusinessUnitCategoryRequest>.WithActionResult<
        CreateBusinessUnitCategoryResponse>
    {
        private readonly IRepository<BusinessUnit> _businessUnitRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<BusinessUnitCategory> _repository;

        public Create(
            IRepository<BusinessUnitCategory> repository,
            IRepository<BusinessUnit> businessUnitRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _businessUnitRepository = businessUnitRepository;
        }

        [HttpPost("api/businessUnitCategories")]
        [SwaggerOperation(
            Summary = "Creates a new BusinessUnitCategory",
            Description = "Creates a new BusinessUnitCategory",
            OperationId = "businessUnitCategories.create",
            Tags = new[] { "BusinessUnitCategoryEndpoints" })
        ]
        public override async Task<ActionResult<CreateBusinessUnitCategoryResponse>> HandleAsync(
            CreateBusinessUnitCategoryRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateBusinessUnitCategoryResponse(request.CorrelationId());

            //var businessUnit = await _businessUnitRepository.GetByIdAsync(request.BusinessUnitId);// parent entity

            var newBusinessUnitCategory = new BusinessUnitCategory(
                request.BusinessUnitId,
                request.RegionAreaAdvisorCategoryId
            );


            await _repository.AddAsync(newBusinessUnitCategory);

            _logger.LogInformation(
                $"BusinessUnitCategory created  with Id {newBusinessUnitCategory.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<BusinessUnitCategoryDto>(newBusinessUnitCategory);

            var businessUnitCategoryCreatedEvent =
                new BusinessUnitCategoryCreatedEvent(newBusinessUnitCategory, "Mongo-History");
            _messagePublisher.Publish(businessUnitCategoryCreatedEvent);

            response.BusinessUnitCategory = dto;


            return Ok(response);
        }
    }
}