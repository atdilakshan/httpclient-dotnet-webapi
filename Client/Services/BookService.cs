using Client.Models;
using System.Text.Json;

namespace Client.Services
{
    public class BookService
    {
        private readonly ILogger<BookService> _logger;
        private readonly HttpClient _httpClient;

        public BookService(ILogger<BookService> logger, HttpClient httpClient)
        {
            this._logger = logger;
            this._httpClient = httpClient;
        }

        public async Task<List<Book>> GetBooks()
        {
            try
            {
                _logger.LogInformation($"Client: Start: GetBooks method called! {DateTime.UtcNow:hh.mm.ss.ffffff}");

                var books = new List<Book>()
                {
                new Book { Title = "Book 1", Author = "Author 1" },
                new Book { Title = "Book 2", Author = "Author 2" }
            };

                var response = books;

                _logger.LogInformation($"Client: Finish: GetBooks method finished! {DateTime.UtcNow:hh.mm.ss.ffffff}");
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            };
        }

        public async Task<List<Book>> GetBooksAsync()
        {
            try
            {
                _logger.LogInformation($"Client: Start: GetBooks method called! {DateTime.UtcNow:hh.mm.ss.ffffff}");

                // Make an HTTP GET request to the server's endpoint
                HttpResponseMessage response = await _httpClient.GetAsync("https://localhost:7037/api/Book");

                response.EnsureSuccessStatusCode(); // Throw an exception if not successful

                // Read the response content as a string
                string responseBody = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // This allows for case-insensitive property matching
                };

                var books = JsonSerializer.Deserialize<List<Book>>(responseBody, options);

                _logger.LogInformation($"Client: Finish: GetBooks method finished! {DateTime.UtcNow:hh.mm.ss.ffffff}");
                return books;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                throw new Exception(ex.Message);
            }
        }
    }
}
