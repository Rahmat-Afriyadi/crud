using BookCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly MyDbContext _dbContext;

        public BooksController(MyDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            return await _dbContext.Books.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            if (book == null) { return NotFound(); };
            return book;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostData(Book book)
        {
            Console.WriteLine(book);
            _dbContext.Books.Add(book);
            var result = await _dbContext.SaveChangesAsync();
            if (result > 0)
                return Ok(new { message = "absensi berhasil ditambah", statusCode = 200 });

            return book;

        }


    }
}
