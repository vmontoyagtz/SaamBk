using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.Invoice;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateInvoiceRequest>.WithActionResult<
        CreateInvoiceResponse>
    {
        private readonly IRepository<Account> _accountRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Invoice> _repository;

        public Create(
            IRepository<Invoice> repository,
            IRepository<Account> accountRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _accountRepository = accountRepository;
        }

        [HttpPost("api/invoices")]
        [SwaggerOperation(
            Summary = "Creates a new Invoice",
            Description = "Creates a new Invoice",
            OperationId = "invoices.create",
            Tags = new[] { "InvoiceEndpoints" })
        ]
        public override async Task<ActionResult<CreateInvoiceResponse>> HandleAsync(
            CreateInvoiceRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateInvoiceResponse(request.CorrelationId());

            //var account = await _accountRepository.GetByIdAsync(request.AccountId);// parent entity

            var newInvoice = new Invoice(
                Guid.NewGuid(),
                request.AccountId,
                request.FinancialAccountingPeriodId,
                request.InvoiceNumber,
                request.AccountName,
                request.CustomerName,
                request.PaymentState,
                request.InternalComments,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.InvoicedDate,
                request.InvoicingNote,
                request.TotalSale,
                request.TotalSaleTax,
                request.TenantId
            );


            await _repository.AddAsync(newInvoice);

            _logger.LogInformation(
                $"Invoice created  with Id {newInvoice.InvoiceId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<InvoiceDto>(newInvoice);

            var invoiceCreatedEvent = new InvoiceCreatedEvent(newInvoice, "Mongo-History");
            _messagePublisher.Publish(invoiceCreatedEvent);

            response.Invoice = dto;


            return Ok(response);
        }
    }
}