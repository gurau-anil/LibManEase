using FluentValidation;
using LibManEase.Application.Contracts.Services;
using LibManEase.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibManEase.Api.Controllers
{
    public class BooksController : ApiControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IValidator<CreateBookDto> _validator;
        public BooksController(IBookService bookService, IValidator<CreateBookDto> validator)
        {
            _bookService = bookService;
            _validator = validator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _bookService.GetAllAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBook(int id)
        {
            var book = await _bookService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook(CreateBookDto createBookDto)
        {
            return await ValidateAndExecuteAsync(createBookDto, async () =>
            {
                var createdBook = await _bookService.CreateAsync(createBookDto);
                return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
            });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, UpdateBookDto updateBookDto)
        {
            if (id != updateBookDto.Id)
            {
                return BadRequest();
            }

            await _bookService.UpdateAsync(updateBookDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAvailableBooks()
        {
            var availableBooks = await _bookService.GetAvailableBooksAsync();
            return Ok(availableBooks);
        }
    }

}
