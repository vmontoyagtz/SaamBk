using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SaamApp.BlazorMauiShared.Models.Invoice;
using SaamApp.Domain.Entities;
using SaamApp.Domain.Events;
using SaamApp.Domain.ModelsDto;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace BusinessManagement.Api.InvoiceEndpoints
{
    public class Update : EndpointBaseAsync.WithRequest<UpdateInvoiceRequest>.WithActionResult<UpdateInvoiceResponse>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationMessagePublisher _messagePublisher;
        private readonly IRepository<Invoice> _repository;

        public Update(
            IRepository<Invoice> repository,
            IApplicationMessagePublisher messagePublisher,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPut("api/invoices")]
        [SwaggerOperation(
            Summary = "Updates a Invoice",
            Description = "Updates a Invoice",
            OperationId = "invoices.update",
            Tags = new[] { "InvoiceEndpoints" })
        ]
        public override async Task<ActionResult<UpdateInvoiceResponse>> HandleAsync(UpdateInvoiceRequest request,
            CancellationToken cancellationToken)
        {
            var response = new UpdateInvoiceResponse(request.CorrelationId());

            var invToUpdate = _mapper.Map<Invoice>(request);

            var invoiceToUpdateTest = await _repository.GetByIdAsync(request.InvoiceId);
            if (invoiceToUpdateTest is null)
            {
                return NotFound();
            }

            invToUpdate.UpdateAccountForInvoice(request.AccountId);
            invToUpdate.UpdateFinancialAccountingPeriodForInvoice(request.FinancialAccountingPeriodId);
            await _repository.UpdateAsync(invToUpdate);

            var invoiceUpdatedEvent = new InvoiceUpdatedEvent(invToUpdate, "Mongo-History");
            _messagePublisher.Publish(invoiceUpdatedEvent);

            var dto = _mapper.Map<InvoiceDto>(invToUpdate);
            response.Invoice = dto;

            return Ok(response);
        }
    }
}