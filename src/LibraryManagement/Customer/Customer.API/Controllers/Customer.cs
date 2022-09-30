using Microsoft.AspNetCore.Mvc;
using Customer.API.Model;
using Customer.Infra.Repository;
using AutoMapper;
using Customer.Infra.DomainModel;

namespace Customer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private ICustomerRepository _repository;
        private readonly IMapper _mapper;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ILogger<CustomerController> logger, ICustomerRepository customerRepository, IMapper mapper)
        {
            _logger = logger;
            _repository = customerRepository;
            _mapper = mapper;
        }

        [HttpGet(Name = "GetAllCustomers")]
        public async Task<IEnumerable<Model.Customer>> Get()
        {
            var customers = await _repository.GetAllCustomers();
            var customerModel = _mapper.Map<IEnumerable<Model.Customer>>(customers);

            return customerModel;
        }

        [HttpGet("{email}")]
        public async Task<Model.Customer> GetByEmail(string email)
        {

            var customer = await _repository.GetCustomerByEmail(email);
            var customerModel = _mapper.Map<Model.Customer>(customer);

            return customerModel;

        }

        [HttpPost(Name = "CreateCustomer")]
        public async Task<Model.Customer> Post(Model.Customer customer)
        {
            var customerModel = _mapper.Map<CustomerModel>(customer);
            var newcustomer = await _repository.CreateCustomer(customerModel);

            return _mapper.Map<Model.Customer>(newcustomer);
        }

        [HttpPatch("{customerId}")]
        public async Task<Model.Customer> Patch(string customerId, Model.Customer customer)
        {
            var customerModel = _mapper.Map<CustomerModel>(customer);
            var updatedcustomer = await _repository.UpdateCustomer(customerId, customerModel);
            if (updatedcustomer == null)
                throw new KeyNotFoundException($"Customer by id {customerId} not found");

            return _mapper.Map<Model.Customer>(updatedcustomer);
        }

    }
}