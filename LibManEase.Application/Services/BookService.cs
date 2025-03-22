using AutoMapper;
using LibManEase.Application.Contracts.Logging;
using LibManEase.Application.Contracts.Services;
using LibManEase.Application.DTOs;
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;

namespace LibManEase.Application.Services
{
    public class BookService : GenericService<Book, BookDto, CreateBookDto, UpdateBookDto>, IBookService
    {
        private readonly IBookRepository _bookRepository;
        protected readonly IAppLogger _logger;
        public BookService(IBookRepository bookRepository, IMapper mapper, IAppLogger logger)
            : base(bookRepository, mapper, logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<BookDto>> GetAvailableBooksAsync()
        {
            var availableBooks = await _bookRepository.GetAvailableBooksAsync();
            return _mapper.Map<IEnumerable<BookDto>>(availableBooks);
        }
    }

}
