using Microsoft.AspNetCore.Mvc;
using Server.Services;

namespace Server.Controllers
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
    }
}
