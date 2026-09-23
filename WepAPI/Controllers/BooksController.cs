using Microsoft.AspNetCore.Mvc;
using WepAPI.Data;

namespace WepAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public BooksController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET http://localhost:port/api/books/get-all-books
        [HttpGet("get-all-books")]
        public IActionResult GetAll()
        {
            var allBooksDomain = _dbContext.Books;
            var allBooksDTO = allBooksDomain.Select(Books => new Models.DTO.BookWithAuthorAndPublisherDTO()
            {
                Id = Books.Id,
                Title = Books.Title,
                Description = Books.Description,
                IsRead = Books.IsRead,
                DateRead = Books.IsRead ? Books.DateRead : null,
                Rate = Books.IsRead ? Books.Rate : null,
                Genre = Books.Genre,
                CoverUrl = Books.CoverUrl,
                PublisherName = Books.Publisher.Name,
                AuthorNames = Books.Book_Authors.Select(n => n.Author.FullName).ToList()
            }).ToList();
            return Ok(allBooksDTO);
        }
    }
}