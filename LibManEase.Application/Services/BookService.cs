using AutoMapper;
using LibManEase.Application.Contracts.Services;
using LibManEase.Application.DTOs;
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;

namespace LibManEase.Application.Services
{
    public class BookService : GenericService<Book, BookDto, CreateBookDto, UpdateBookDto>, IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository, IMapper mapper)
            : base(bookRepository, mapper)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<BookDto>> GetAvailableBooksAsync()
        {
            var availableBooks = await _bookRepository.GetAvailableBooksAsync();
            return _mapper.Map<IEnumerable<BookDto>>(availableBooks);
        }
    }

}
