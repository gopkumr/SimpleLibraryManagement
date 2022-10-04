using Dapper;
using Dapper.Contrib.Extensions;
using Lending.Infra.DomainModel;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending.Infra.Repository
{
    public class BorrowingMySqlRepository : IBorrowingRepository
    {
        MySqlConnection _mySqlConnection;

        public BorrowingMySqlRepository(IOptions<MySQLDbSettings> settings)
        {
            _mySqlConnection = new MySqlConnection(settings.Value.ConnectionString);
        }
        
        public Borrowing BorrowBook(string bookId, string customerId)
        {
            var borrowing = new Borrowing { BookId = bookId, CustomerId = customerId, BorrowedDate = DateTime.Today, BorrowingExpiryDate = DateTime.Today.AddDays(14) };
            _mySqlConnection.Insert<Borrowing>(borrowing);
            return borrowing;
        }

        public async Task<IEnumerable<Borrowing>> GetBookBorrowingStatus(string bookId)
        {
            var borrowing = await _mySqlConnection.QueryAsync<Borrowing>("SELECT * FROM Borrowings WHERE BookId=@bookId", new { bookId });
            return borrowing.ToList();
        }

        public Borrowing GetBookCustomerBorrowingStatus(string bookId, string customerId)
        {
            var borrowing =  _mySqlConnection.QueryFirstOrDefault<Borrowing>("SELECT * FROM Borrowings WHERE BookId=@bookId AND CustomerId=@customerId", new { bookId, customerId });
            return borrowing;

        }

        public async Task<IEnumerable<Borrowing>> GetCustomerBorrowingStatu(string customerId)
        {
            var borrowing = await _mySqlConnection.QueryAsync<Borrowing>("SELECT * FROM Borrowings WHERE CustomerId=@customerId", new { customerId });
            return borrowing.ToList();
        }

        public bool ReturnBook(string bookId, string customerId)
        {
            var existingBorrowing = GetBookCustomerBorrowingStatus(bookId, customerId);
            return _mySqlConnection.Delete<Borrowing>(existingBorrowing);
        }
    }
}
