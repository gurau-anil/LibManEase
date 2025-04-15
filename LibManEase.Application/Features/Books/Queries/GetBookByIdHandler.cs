using AutoMapper;
using LibManEase.Application.Abstraction.DTOs;
using LibManEase.Application.Abstraction.Features.Books.Queries;
using LibManEase.Domain.Contracts;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibManEase.Application.Implementation.Features.Books.Queries
{
    public class GetBookByIdHandler : IRequestHandler<GetBookById, BookDto>
    {
        private readonly IMapper _mapper;
        private readonly IBookRepository _bookRepository;
        public GetBookByIdHandler(IMapper mapper, IBookRepository bookRepository)
        {
            _mapper = mapper;
            _bookRepository = bookRepository;
        }
        public async Task<BookDto> Handle(GetBookById request, CancellationToken cancellationToken)
        {
            return _mapper.Map<BookDto>(await _bookRepository.GetByIdAsync(request.Id));
        }
    }
}
