using Inventory.Infra.Db;
using Inventory.Infra.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Infra.Repository
{
    public class BookEFCoreRepository : IBookRepository
    {
        private readonly InventoryDbContext _dbContext;

        public BookEFCoreRepository(InventoryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<BookModel> AddNewBook(BookModel book)
        {
            var addedModel = await _dbContext.books.AddAsync(book);
            await _dbContext.SaveChangesAsync();

            return addedModel.Entity;
        }

        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            var books = await _dbContext.books.OrderBy(q => q.Title).ToListAsync();
            return books;
        }

        public async Task<BookModel?> GetBookById(string id)
        {
            var book = await _dbContext.books.FirstOrDefaultAsync(q => q.Id.ToUpper() == id.ToUpper());
            return book;
        }

        public async Task<BookModel?> GetBookByTitle(string title)
        {
            var book = await _dbContext.books.FirstOrDefaultAsync(q => q.Title.ToUpper() == title.ToUpper());
            return book;
        }

        public async Task<IEnumerable<BookModel>> GetBooksByAuthor(string author)
        {
            var books = await _dbContext.books.Where(q => q.Author.ToUpper() == author.ToUpper()).ToListAsync();
            return books;
        }

        public async Task<BookModel?> UpdateBook(string bookId, BookModel book)
        {
            var bookToUpdate = await GetBookById(bookId);
            if (bookToUpdate == null)
                throw new KeyNotFoundException($"Could not find book by Id {bookId}");
            bookToUpdate.Author = book.Author;
            bookToUpdate.CoverPageImpageName = book.CoverPageImpageName;
            bookToUpdate.FrontMatter = book.FrontMatter;
            bookToUpdate.Quantity = book.Quantity;
            bookToUpdate.Title = book.Title;

            _dbContext.Attach(bookToUpdate);
            await _dbContext.SaveChangesAsync();

            return bookToUpdate;
        }

        public async Task<BookModel?> UpdateBookQuantity(string bookId, int quantity)
        {
            var bookToUpdate = await GetBookById(bookId);
            if (bookToUpdate == null)
                throw new KeyNotFoundException($"Could not find book by Id {bookId}");
           
            bookToUpdate.Quantity = quantity;
           

            _dbContext.Attach(bookToUpdate);
            await _dbContext.SaveChangesAsync();

            return bookToUpdate;
        }
    }
}
