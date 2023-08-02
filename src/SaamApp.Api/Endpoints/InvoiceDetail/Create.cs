using System;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaamApp.BlazorMauiShared.Models.InvoiceDetail;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.TeachingMaterial.Strategies.Discount;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceDetailEndpoints
{
    public class Create : EndpointBaseAsync.WithRequest<CreateInvoiceDetailRequest>.WithActionResult<
        CreateInvoiceDetailResponse>
    {
        private readonly IRepository<Invoice> _invoiceRepository;

        private readonly ILogger<Create> _logger;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<InvoiceDetail> _repository;

        public Create(
            IRepository<InvoiceDetail> repository,
            IRepository<Invoice> invoiceRepository,
            IMapper mapper,
            IApplicationMessagePublisher messagePublisher,
            ILogger<Create> logger
        )
        {
            _mapper = mapper;
            _messagePublisher = messagePublisher;
            _logger = logger;
            _repository = repository;
            _invoiceRepository = invoiceRepository;
        }

        [HttpPost("api/invoiceDetails")]
        [SwaggerOperation(
            Summary = "Creates a new InvoiceDetail",
            Description = "Creates a new InvoiceDetail",
            OperationId = "invoiceDetails.create",
            Tags = new[] { "InvoiceDetailEndpoints" })
        ]
        public override async Task<ActionResult<CreateInvoiceDetailResponse>> HandleAsync(
            CreateInvoiceDetailRequest request,
            CancellationToken cancellationToken)

        {
            var response = new CreateInvoiceDetailResponse(request.CorrelationId());

            //var invoice = await _invoiceRepository.GetByIdAsync(request.InvoiceId);// parent entity

            var newInvoiceDetail = new InvoiceDetail(
                Guid.NewGuid(),
                request.InvoiceId,
                request.ProductId,
                request.CreatedAt,
                request.CreatedBy,
                request.UpdatedAt,
                request.UpdatedBy,
                request.Quantity,
                request.ProductName,
                request.UnitPrice,
                request.LineSale,
                request.LineTax,
                request.LineDiscount
            );

            IDiscountStrategy discountStrategyInstance = null;
            switch (request.DiscountStrategy)
            {
                case "PowerBuyer":
                    discountStrategyInstance = new PowerBuyerDiscountStrategy();
                    break;
                case "RegularCustomer":
                    discountStrategyInstance = new RegularCustomerDiscountStrategy();
                    break;
                default:
                    return BadRequest("Invalid discount strategy");
            }

            var discount = discountStrategyInstance.CalculateDiscount(newInvoiceDetail);
            request.LineSale -= request.LineSale * discount;

            await _repository.AddAsync(newInvoiceDetail);

            _logger.LogInformation(
                $"InvoiceDetail created  with Id {newInvoiceDetail.InvoiceDetailId.ToString("D", CultureInfo.InvariantCulture)}");

            var dto = _mapper.Map<InvoiceDetailDto>(newInvoiceDetail);

            var invoiceDetailCreatedEvent = new InvoiceDetailCreatedEvent(newInvoiceDetail, "Mongo-History");
            _messagePublisher.Publish(invoiceDetailCreatedEvent);

            response.InvoiceDetail = dto;


            return Ok(response);
        }
    }
}