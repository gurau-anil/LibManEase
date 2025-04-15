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
    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public CreateBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = new Book { };
            await _bookRepository.AddAsync(book);
            return book.Id;
        }
    }
}
