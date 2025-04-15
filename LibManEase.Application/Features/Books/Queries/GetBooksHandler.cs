using AutoMapper;
using LibManEase.Application.Abstraction.DTOs;
using LibManEase.Application.Abstraction.Features.Books.Queries;
using LibManEase.Domain.Contracts;
using MediatR;

namespace LibManEase.Application.Implementation.Features.Books.Queries
{
    public class GetBooksHandler : IRequestHandler<GetBooks, IEnumerable<BookDto>>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public GetBooksHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<IEnumerable<BookDto>> Handle(GetBooks request, CancellationToken cancellationToken)
        {
            return _mapper.Map<IEnumerable<BookDto>>(await _bookRepository.GetAllAsync());
        }
    }
}
