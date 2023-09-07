using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using SampleData.Data;
using System.Collections;

namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository bookRepository;

        public BookController(IBookRepository bookRepository,IMapper mapper)
        {
            this.bookRepository = bookRepository;
        }

        [HttpGet("getbooks")]
        public async Task<ActionResult<IEnumerable>> GetBooks()
        {
            var books = await bookRepository.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("getBooksById")]
        public async Task<ActionResult<List<Book>>> getBooksById(int id)
        {
            var books = await bookRepository.GetbooksById(id);
            return Ok(books);
        }

        [HttpGet("getallBooks")]
        public async Task<ActionResult<IEnumerable>> GetAllbooks()
        {
            var books = await bookRepository.GetAllbooks();
            return Ok(books);
        }

        [HttpPost("PostBooks")]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            if (book == null)
            {
                return BadRequest();
            }
            var books = await bookRepository.AddAsynch(book);
            return Ok(books);
        }

    }
}
