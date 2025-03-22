using AutoMapper;
using LibManEase.Application.Abstraction.DTOs;
using LibManEase.Domain.Entities;

namespace LibManEase.Application.Implementation.Mappings
{
    internal class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Book Mappings
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Book, CreateBookDto>().ReverseMap();
            CreateMap<Book, UpdateBookDto>().ReverseMap();

            // Member Mappings
            CreateMap<Member, MemberDto>().ReverseMap();
            CreateMap<Member, CreateMemberDto>().ReverseMap();
            CreateMap<Member, UpdateMemberDto>().ReverseMap();

            // Loan Mappings
            CreateMap<Loan, LoanDto>()
                .ForMember(dest => dest.BookTitle, opt => opt.MapFrom(src => src.Book.Title))
                .ForMember(dest => dest.MemberName, opt => opt.MapFrom(src => $"{src.Member.FirstName} {src.Member.LastName}"))
                .ReverseMap();
            CreateMap<Loan, CreateLoanDto>().ReverseMap();
            CreateMap<Loan, UpdateLoanDto>().ReverseMap();
        }
    }
}
    
