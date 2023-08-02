using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Gender;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.GenderEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateGenderRequest>.WithActionResult<
        CreateGenderResponse>
    {
        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Gender> _repository;

        public Create(
            IRepository<Gender> repository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
        }

        [HttpPost("api/genders")]
        [SwaggerOperation(
            Summary = "Creates a new Gender",
            Description = "Creates a new Gender",
            OperationId = "genders.create",
            Tags = new[] { "GenderEndpoints" })
        ]
        public override async Task<ActionResult<CreateGenderResponse>> HandleAsync(
            CreateGenderRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateGenderResponse(request.CorrelationId());


            var newGender = new Gender(
                Guid.NewGuid(),
                request.GenderName
            );


            await _repository.AddAsync(newGender);

            _logger.LogInformation(
                $"Gender created  with Id {newGender.GenderId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<GenderDto>(newGender);

            var genderCreatedEvent = new GenderCreatedEvent(newGender, "Mongo-History");
            _messagePublisher.Publish(genderCreatedEvent);

            response.Gender = dto;


            return Ok(response);
        }
    }
}