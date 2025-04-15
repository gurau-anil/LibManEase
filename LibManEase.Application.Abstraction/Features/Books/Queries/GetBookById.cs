using LibManEase.Application.Abstraction.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibManEase.Application.Abstraction.Features.Books.Queries
{
    public record GetBookById(int Id): IRequest<BookDto>
    {
    }
}
