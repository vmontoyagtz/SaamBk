using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Ardalis.ApiEndpoints;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SaamApp.Api.Hubs;
using SaamApp.BlazorMauiShared.Models.Customer;
using SaamApp.Domain.Entities;
using SaamApp.Domain.ModelsDto;
using SaamApp.Domain.Specifications;
using SaamAppLib.SharedKernel.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SaamApp.Api.CustomerEndpoints
{
    public class List : EndpointBaseAsync.WithRequest<ListCustomerRequest>.WithActionResult<ListCustomerResponse>
    {
        private readonly IMapper _mapper;
        private readonly IRepository<Customer> _repository;

        private readonly IHubContext<SaamApiSignalrHub>
            _saamApiHub;

        public List(IRepository<Customer> repository,
            IHubContext<SaamApiSignalrHub> SaamApiHub,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
            _saamApiHub = SaamApiHub;
        }

        [HttpGet("api/customers")]
        [SwaggerOperation(
            Summary = "List Customers",
            Description = "List Customers",
            OperationId = "customers.List",
            Tags = new[] { "CustomerEndpoints" })
        ]
        public override async Task<ActionResult<ListCustomerResponse>> HandleAsync(
            [FromQuery] ListCustomerRequest request,
            CancellationToken cancellationToken)
        {
            var response = new ListCustomerResponse(request.CorrelationId());

            var spec = new CustomerGetListSpec();
            try
            {
                var customers1 = await _repository.ListAsync(spec);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var customers = await _repository.ListAsync(spec);
            if (customers is null)
            {
                return NotFound();
            }

            response.Customers = _mapper.Map<List<CustomerDto>>(customers);
            response.Count = response.Customers.Count;
            var notification = $"Customer {response.Count.ToString()} . ";
           
            await _saamApiHub.Clients.All.SendAsync("ReceiveMessageFromApiServer", notification);
            return Ok(response);
        }
    }
}