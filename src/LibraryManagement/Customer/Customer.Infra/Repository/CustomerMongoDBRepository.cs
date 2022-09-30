using Customer.Infra.DomainModel;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Customer.Infra.Repository
{
    public class CustomerMongoDBRepository : ICustomerRepository
    {

        private IMongoCollection<CustomerModel> _customerCollection;

        public CustomerMongoDBRepository(IOptions<MongoDBSettings> settings)
        {
            MongoClient client = new MongoClient(settings.Value.ConnectionURI);
            IMongoDatabase database = client.GetDatabase(settings.Value.DatabaseName);
            _customerCollection = database.GetCollection<CustomerModel>("customers");
        }


        public async Task<CustomerModel> CreateCustomer(CustomerModel customer)
        {
            var existing = await GetCustomerByEmail(customer.Email);
            if (existing != null)
                throw new InvalidDataException($"Customer with email {customer.Email} already exists");

            await _customerCollection.InsertOneAsync(customer);
            return customer;
        }

        public async Task<IEnumerable<CustomerModel>> GetAllCustomers()
        {
            var customers = await _customerCollection.FindSync(c => !string.IsNullOrEmpty(c.Email)).ToListAsync();
            return customers;
        }

        public async Task<CustomerModel> GetCustomerByEmail(string email)
        {
            var customer = await _customerCollection.FindSync(c => c.Email.ToUpper() == email.ToUpper()).FirstOrDefaultAsync();
            return customer;
        }

        public async Task<CustomerModel?> UpdateCustomer(string customerId, CustomerModel customer)
        {
            var update = Builders<CustomerModel>.Update.Set(f => f.Address, customer.Address)
                                                       .Set(f => f.Email, customer.Email)
                                                       .Set(f => f.Name, customer.Name);

            var existingCustomer = await _customerCollection.FindSync(c => c.Id.ToUpper() == customerId.ToUpper()).FirstOrDefaultAsync();
            if (existingCustomer != null)
            {
                var updateResult = await _customerCollection.UpdateOneAsync(c => c.Id.ToUpper() == customerId.ToUpper(), update);
                return customer;
            }

            return null;
        }
    }
}
