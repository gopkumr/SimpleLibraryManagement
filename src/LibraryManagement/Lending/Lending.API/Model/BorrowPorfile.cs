using AutoMapper;
using Lending.Infra.DomainModel;

namespace Lending.API.Model
{
    public class BorrowProfile:Profile
    {
        public BorrowProfile()
        {
            CreateMap<Borrowing, Borrow>();
        }
    }
}
