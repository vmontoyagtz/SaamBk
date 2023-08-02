using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.StudyAids_TrainingResources.EventStoreDb
{
    public class CustomerChangedEvent
    {
        public int CustomerId { get; set; }
        public string PropertyName { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public DateTime Timestamp { get; set; }
    }

    public class UpdateCustomerCommand : IRequest
    {
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        // serilog

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            //// Get the old customer from the event store
            //var events = await eventStore.GetEvents(request.CustomerId);
            //var oldCustomer = events.Aggregate(new Customer(), (customer, @event) => customer.Apply(@event));

            //// Update the customer with the new data
            //var mapperConfig = new MapperConfiguration(cfg => cfg.CreateMap<CustomerDto, CustomerEntity>());
            //var mapper = mapperConfig.CreateMapper();
            //var newCustomer = mapper.Map<Customer>(request.Customer);
            //newCustomer.Id = request.CustomerId;

            //// Compare the old and new customers and create events for the changes
            //var changedProperties = oldCustomer.Compare(newCustomer);
            //var changeEvents = changedProperties.Select(property =>
            //    new CustomerChangedEvent
            //    {
            //        CustomerId = request.CustomerId,
            //        PropertyName = property.Name,
            //        OldValue = property.OldValue,
            //        NewValue = property.NewValue,
            //        Timestamp = DateTime.UtcNow
            //    });

            //// Save the events to the event store
            //await eventStore.AppendEvents(request.CustomerId, changeEvents);


            return Unit.Value;
        }
    }

    //using Newtonsoft.Json.Linq;

    //public static bool AreObjectsEqual(object obj1, object obj2)
    //{
    //    var obj1Json = JToken.FromObject(obj1);
    //    var obj2Json = JToken.FromObject(obj2);

    //    return JToken.DeepEquals(obj1Json, obj2Json);
    //}
}