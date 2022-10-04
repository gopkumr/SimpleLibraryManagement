namespace Lending.API.Model
{
    public class Borrow
    {
        public string BorrowId { get; set; }
        public string CustomerId { get; set; }
        public string BookId { get; set; }
        public DateTime BorrowedDate { get; set; }
        public DateTime BorrowingExpiryDate { get; set; }
    }
}
