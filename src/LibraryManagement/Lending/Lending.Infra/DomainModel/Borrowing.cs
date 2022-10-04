using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lending.Infra.DomainModel
{
    public class Borrowing
    {
        [Key]
        public string BorrowingId { get; set; }
        public string CustomerId { get; set; }
        public string BookId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime BorrowingExpiryDate { get; set; }


    }
}
