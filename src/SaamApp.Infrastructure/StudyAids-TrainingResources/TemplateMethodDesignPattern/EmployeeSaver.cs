using SaamApp.Domain.Entities;

namespace SaamApp.Infrastructure.TemplateMethodDesignPattern
{
    public abstract class EmployeeSaver
    {
        public void Save(Employee employee)
        {
            EnrichEmployeeData(employee);
            NotifySubscribers(employee);
        }

        protected abstract void EnrichEmployeeData(Employee employee);


        protected abstract void NotifySubscribers(Employee employee);
    }

    public class EmployeeSmsNotificationSaver : EmployeeSaver
    {
        //private readonly ISmsService _smsService;

        // <Summary>
        // "EnrichEmployeeData". This method could be used to add additional data to the employee object before it is saved. For example, it could generate a unique ID for the employee, or calculate a salary based on the employee's position and experience.
        // </Summary>
        protected override void EnrichEmployeeData(Employee employee)
        {
            // Implement any custom EnrichEmployeeData logic here
        }


        protected override void NotifySubscribers(Employee employee)
        {
            //var phoneNumbers = _employeePhoneNumberRepository
            //    .GetEmployeePhoneNumbers(employee.EmployeeId);

            //foreach (var phoneNumber in phoneNumbers)
            //{
            //    _smsService.SendSms(phoneNumber.Number, "New employee added!");
            //}
        }
    }
}