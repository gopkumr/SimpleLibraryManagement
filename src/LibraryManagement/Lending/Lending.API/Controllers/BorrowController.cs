using AutoMapper;
using Lending.API.Model;
using Lending.Infra.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Lending.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BorrowController : ControllerBase
    {
       
        private readonly ILogger<BorrowController> _logger;
        private readonly IBorrowingRepository _borrowingRepository;
        private readonly IMapper _mapper;

        public BorrowController(ILogger<BorrowController> logger, IBorrowingRepository borrowingRepository, IMapper mapper)
        {
            _logger = logger;
            _borrowingRepository = borrowingRepository;
            _mapper = mapper;
        }

        [HttpPost("borrow")]
        public ActionResult BorrowBook(string bookId, string customerId)
        {
            var borrow=_borrowingRepository.BorrowBook(bookId, customerId);
            var borrowModel = _mapper.Map<Borrow>(borrow);

            return Content(JsonConvert.SerializeObject(borrowModel), "application/json");
        }

        [HttpPost("return")]
        public ActionResult ReturnBook(string bookId, string customerId)
        {
            var borrow = _borrowingRepository.ReturnBook(bookId, customerId);
           
            return Ok();
        }

        [HttpGet("bookstatus")]
        public async Task<ActionResult>  GetBookBorrowingStatus(string bookId)
        {
            var borrow = await _borrowingRepository.GetBookBorrowingStatus(bookId);
            var borrowModel = _mapper.Map<IEnumerable<Borrow>>(borrow);

            return Content(JsonConvert.SerializeObject(borrowModel), "application/json");
        }

        [HttpGet("customerstatus")]
        public async Task<ActionResult> GetCustomerBorrowingStatu(string customerId)
        {
            var borrow = await _borrowingRepository.GetCustomerBorrowingStatu(customerId);
            var borrowModel = _mapper.Map<IEnumerable<Borrow>>(borrow);

            return Content(JsonConvert.SerializeObject(borrowModel), "application/json");
        }
    }
}