using AutoMapper;
using Inventory.API.Model;
using Inventory.Infra.DomainModel;
using Inventory.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net;

namespace Inventory.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookController> _logger;

        public BookController(IBookRepository bookRepository, IMapper mapper, ILogger<BookController> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddNewBook(Book book)
        {
            var bookModel = _mapper.Map<BookModel>(book);
            var newbook = await _bookRepository.AddNewBook(bookModel);
            return new CreatedAtActionResult("GetBookById", "Inventory", newbook.Id, newbook);
        }

        [HttpPatch("{bookId}")]
        public async Task<ActionResult> UpdateBook(string bookId, Book book)
        {
            var bookModel = _mapper.Map<BookModel>(book);
            var updatedBook = await _bookRepository.UpdateBook(bookId, bookModel);
            if (updatedBook == null)
            {
                return new NotFoundObjectResult(bookId);
            }

            return new OkResult();
        }

        [HttpPatch("{bookId}/quantity/{quantity}")]
        public async Task<ActionResult?> UpdateBookQuantity(string bookId, int quantity)
        {

            var updatedBook = await _bookRepository.UpdateBookQuantity(bookId, quantity);
            if (updatedBook == null)
            {
                return new NotFoundObjectResult(bookId);
            }

            return new OkResult();
        }

        [HttpGet]
        public async Task<ActionResult> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return new ContentResult() { Content = JsonConvert.SerializeObject(books) , ContentType = "application/json" };
        }


        [HttpGet("author/{author}")]
        public async Task<ActionResult> GetBooksByAuthor(string author)
        {
            var books = await _bookRepository.GetBooksByAuthor(author);
            return new ContentResult() { Content = JsonConvert.SerializeObject(books), ContentType = "application/json" };
        }

        [HttpGet("title/{title}")]
        public async Task<ActionResult> GetBookByTitle(string title)
        {
            var book = await _bookRepository.GetBookByTitle(title);
            return new ContentResult() { Content = JsonConvert.SerializeObject(book), ContentType = "application/json" };
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetBookById(string id)
        {
            var book = await _bookRepository.GetBookById(id);
            return new ContentResult() { Content = JsonConvert.SerializeObject(book), ContentType = "application/json" };
        }
    }
}