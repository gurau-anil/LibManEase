using FluentValidation;
using LibManEase.Application.Abstraction.Contracts.Logging;
using LibManEase.Application.Abstraction.Contracts.Services;
using LibManEase.Application.Abstraction.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibManEase.Api.Controllers
{
    public class BooksController : ApiControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IValidator<CreateBookDto> _validator;
        private readonly IAppLogger _logger;
        public BooksController(IBookService bookService, IValidator<CreateBookDto> validator, IAppLogger logger)
        {
            _bookService = bookService;
            _validator = validator;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            _logger.LogInformation("Entry -> Controller: BookController, Method: GetAllBooks");
            var books = await _bookService.GetAllAsync();
            _logger.LogInformation("Exit -> Controller: BookController, Method: GetAllBooks");
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
            return await ValidateAndExecuteAsync(updateBookDto, async () =>
            {
                await _bookService.UpdateAsync(updateBookDto);
                return NoContent();
            });
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
