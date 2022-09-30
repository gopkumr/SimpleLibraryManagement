using AutoMapper;
using Customer.Infra.DomainModel;

namespace Customer.API.Model
{
    public class CustomerProfile:Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerModel, Customer>().ReverseMap();
        }
    }
}
