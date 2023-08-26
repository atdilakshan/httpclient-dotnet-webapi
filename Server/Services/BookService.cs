using Server.Models;

namespace Server.Services
{
    public class BookService
    {
        private readonly ILogger<BookService> _logger;

        public BookService(ILogger<BookService> logger)
        {
            this._logger = logger;
        }

        public async Task<List<Book>> GetBooks()
        {
            try
            {
                _logger.LogInformation($"Server: Start: GetBooks method called! {DateTime.UtcNow:hh.mm.ss.ffffff}");

                var books = new List<Book>()
                {
                new Book { Title = "Book 1", Author = "Author 1" },
                new Book { Title = "Book 2", Author = "Author 2" },
            };

                var response = books;

                _logger.LogInformation($"Server: Finish: GetBooks method finished! {DateTime.UtcNow:hh.mm.ss.ffffff}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            };
        }
    }
}
