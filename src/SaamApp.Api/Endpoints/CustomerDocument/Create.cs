using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.CustomerDocument;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerDocumentEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateCustomerDocumentRequest>.WithActionResult<
        CreateCustomerDocumentResponse>
    {
        private readonly IRepository<Customer> _customerRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<CustomerDocument> _repository;

        public Create(
            IRepository<CustomerDocument> repository,
            IRepository<Customer> customerRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _customerRepository = customerRepository;
        }

        [HttpPost("api/customerDocuments")]
        [SwaggerOperation(
            Summary = "Creates a new CustomerDocument",
            Description = "Creates a new CustomerDocument",
            OperationId = "customerDocuments.create",
            Tags = new[] { "CustomerDocumentEndpoints" })
        ]
        public override async Task<ActionResult<CreateCustomerDocumentResponse>> HandleAsync(
            CreateCustomerDocumentRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateCustomerDocumentResponse(request.CorrelationId());

            //var customer = await _customerRepository.GetByIdAsync(request.CustomerId);// parent entity

            var newCustomerDocument = new CustomerDocument(
                request.CustomerId,
                request.DocumentId,
                request.DocumentTypeId
            );


            await _repository.AddAsync(newCustomerDocument);

            _logger.LogInformation(
                $"CustomerDocument created  with Id {newCustomerDocument.RowId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<CustomerDocumentDto>(newCustomerDocument);

            var customerDocumentCreatedEvent = new CustomerDocumentCreatedEvent(newCustomerDocument, "Mongo-History");
            _messagePublisher.Publish(customerDocumentCreatedEvent);

            response.CustomerDocument = dto;


            return Ok(response);
        }
    }
}