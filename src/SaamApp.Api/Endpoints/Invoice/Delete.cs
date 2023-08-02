using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Invoice;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteInvoiceRequest>.WithActionResult<
        DeleteInvoiceResponse>
    {
        private readonly IRepository<InvoiceDetail> _invoiceDetailRepository;
        private readonly IRepository<Invoice> _invoiceReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Invoice> _repository;

        public Delete(IRepository<Invoice> InvoiceRepository, IRepository<Invoice> InvoiceReadRepository,
            IRepository<InvoiceDetail> invoiceDetailRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = InvoiceRepository;
            _invoiceReadRepository = InvoiceReadRepository;
            _invoiceDetailRepository = invoiceDetailRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/invoices/{InvoiceId}")]
        [SwaggerOperation(
            Summary = "Deletes an Invoice",
            Description = "Deletes an Invoice",
            OperationId = "invoices.delete",
            Tags = new[] { "InvoiceEndpoints" })
        ]
        public override async Task<ActionResult<DeleteInvoiceResponse>> HandleAsync(
            [FromRoute] DeleteInvoiceRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteInvoiceResponse(request.CorrelationId());

            var invoice = await _invoiceReadRepository.GetByIdAsync(request.InvoiceId);

            if (invoice == null)
            {
                return NotFound();
            }

            var invoiceDetailSpec = new GetInvoiceDetailWithInvoiceKeySpec(invoice.InvoiceId);
            var invoiceDetails = await _invoiceDetailRepository.ListAsync(invoiceDetailSpec);
            await _invoiceDetailRepository
                .DeleteRangeAsync(invoiceDetails); // you could use soft delete with IsDeleted = true
            //foreach (var id in invoiceDetails)
            //{
            //invoice.DeleteInvoiceDetail(id);
            //}

            //await _repository.UpdateAsync(invoice);


            var invoiceDeletedEvent = new InvoiceDeletedEvent(invoice, "Mongo-History");
            _messagePublisher.Publish(invoiceDeletedEvent);

            await _repository.DeleteAsync(invoice);

            return Ok(response);
        }
    }
}