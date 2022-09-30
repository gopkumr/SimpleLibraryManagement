using Customer.Infra.DomainModel;

namespace Customer.Infra.Repository
{
    public interface ICustomerRepository
    {
        public Task<CustomerModel> CreateCustomer(CustomerModel customer);

        public Task<CustomerModel?> UpdateCustomer(string customerId, CustomerModel customer);

        public Task<IEnumerable<CustomerModel>> GetAllCustomers();

        public Task<CustomerModel> GetCustomerByEmail(string email);
    }
}
