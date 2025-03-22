using LibManEase.Application.Abstraction.DTOs;

namespace LibManEase.Application.Abstraction.Contracts.Services
{
    public interface IBookService : IGenericService<BookDto, CreateBookDto, UpdateBookDto>
    {
        Task<IEnumerable<BookDto>> GetAvailableBooksAsync();
    }
}
