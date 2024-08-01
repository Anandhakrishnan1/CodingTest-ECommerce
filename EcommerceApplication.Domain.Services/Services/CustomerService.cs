using EcommerceApplication.DataAccess.Repository;

namespace EcommerceApplication.Domain.Services
{
    public interface ICustomerService
    {
        bool IsValidCustomer(string emailId, string customerId);
    }
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }
        public bool IsValidCustomer(string emailId, string customerId)
        {
            return _customerRepository.CheckIsCustomerValidByEmailAndCustomerId(emailId, customerId);
        }
    }
}
