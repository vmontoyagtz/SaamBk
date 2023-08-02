using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.InvoiceDetail;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.InvoiceDetailEndpoints
{
    public class Delete : EndpointBaseAsync.WithRequest<DeleteInvoiceDetailRequest>.WithActionResult<
        DeleteInvoiceDetailResponse>
    {
        private readonly IRepository<InvoiceDetail> _invoiceDetailReadRepository;
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<InvoiceDetail> _repository;

        public Delete(IRepository<InvoiceDetail> InvoiceDetailRepository,
            IRepository<InvoiceDetail> InvoiceDetailReadRepository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = InvoiceDetailRepository;
            _invoiceDetailReadRepository = InvoiceDetailReadRepository;
            _mapper = mapper;
        }

        [HttpDelete("api/invoiceDetails/{InvoiceDetailId}")]
        [SwaggerOperation(
            Summary = "Deletes an InvoiceDetail",
            Description = "Deletes an InvoiceDetail",
            OperationId = "invoiceDetails.delete",
            Tags = new[] { "InvoiceDetailEndpoints" })
        ]
        public override async Task<ActionResult<DeleteInvoiceDetailResponse>> HandleAsync(
            [FromRoute] DeleteInvoiceDetailRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteInvoiceDetailResponse(request.CorrelationId());

            var invoiceDetail = await _invoiceDetailReadRepository.GetByIdAsync(request.InvoiceDetailId);

            if (invoiceDetail == null)
            {
                return NotFound();
            }


            var invoiceDetailDeletedEvent = new InvoiceDetailDeletedEvent(invoiceDetail, "Mongo-History");
            _messagePublisher.Publish(invoiceDetailDeletedEvent);

            await _repository.DeleteAsync(invoiceDetail);

            return Ok(response);
        }
    }
}