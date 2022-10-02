using Inventory.Infra.DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Infra.Repository
{
    public interface IBookRepository
    {
        public Task<BookModel> AddNewBook(BookModel book);

        public Task<BookModel?> UpdateBook(string bookId, BookModel book);

        public Task<BookModel?> UpdateBookQuantity(string bookId, int quantity);

        public Task<IEnumerable<BookModel>> GetAllBooks();

        public Task<IEnumerable<BookModel>> GetBooksByAuthor(string author);

        public Task<BookModel?> GetBookByTitle(string title);

        public Task<BookModel?> GetBookById(string id);
    }
}
