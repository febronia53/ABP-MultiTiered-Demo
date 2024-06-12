using Acme.BookStore.Books;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace Acme.BookStore.Controllers.Books
{
    [Route("api/books")]
    public class BookController : BookStoreController
    {
        private readonly IBookAppService _bookAppService;

        public BookController(IBookAppService bookAppService)
        {
            _bookAppService = bookAppService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookAsync(Guid id)
        {
            var book = await _bookAppService.GetAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpGet]
        public async Task<ActionResult> GetBookList(PagedAndSortedResultRequestDto request)
        {
            var booksList = await _bookAppService.GetListAsync(request);
            return Ok(booksList);
        }

        [HttpPost]
        public async Task<ActionResult> CreateBook(CreateUpdateBookDto book)
        {
            await _bookAppService.CreateAsync(book);
            return Ok(StatusCode(200));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(Guid id)
        {
            await _bookAppService.DeleteAsync(id);
            return Ok(StatusCode(200));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(Guid id, CreateUpdateBookDto book)
        {
            await _bookAppService.UpdateAsync(id, book);
            return Ok(StatusCode(200));
        }
    }
}
