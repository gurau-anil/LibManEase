using AutoMapper;
using LibManEase.Application.Abstraction.DTOs;
using LibManEase.Application.Abstraction.Features.Books.Commands;
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibManEase.Application.Implementation.Features.Books.Commands
{
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public CreateBookCommandHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<BookDto> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request.model);
            await _bookRepository.AddAsync(book);
            return _mapper.Map<BookDto>(book);
        }
    }
}
