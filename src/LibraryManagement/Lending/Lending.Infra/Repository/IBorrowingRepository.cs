using Lending.Infra.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending.Infra.Repository
{
    public interface IBorrowingRepository
    {
        Borrowing BorrowBook(string bookId, string customerId);

        bool ReturnBook(string bookId, string customerId);
        Borrowing GetBookCustomerBorrowingStatus(string bookId, string customerId);

        Task<IEnumerable<Borrowing>> GetBookBorrowingStatus(string bookId);
        Task<IEnumerable<Borrowing>> GetCustomerBorrowingStatu(string customerId);

    }
}
