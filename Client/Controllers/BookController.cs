using Client.Services;
using Microsoft.AspNetCore.Mvc;

namespace Client.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly BookService _bookService;
        public BookController(BookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var books = await _bookService.GetBooks();
            return Ok(books);
        }

        [HttpGet("http")]
        public async Task<IActionResult> GetAsync()
        {
            var books = await _bookService.GetBooksAsync();
            return Ok(books);
        }
    }
}
