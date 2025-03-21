using LibManEase.Application.DTOs;

namespace LibManEase.Application.Contracts.Services
{
    public interface IBookService : IGenericService<BookDto, CreateBookDto, UpdateBookDto>
    {
        Task<IEnumerable<BookDto>> GetAvailableBooksAsync();
    }
}
