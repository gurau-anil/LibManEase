using LibManEase.Application.Abstraction.DTOs;

namespace LibManEase.Application.Abstraction.Contracts.Services
{
    public interface IMemberService : IGenericService<MemberDto, CreateMemberDto, UpdateMemberDto>
    {
        Task<MemberDto> GetByEmailAsync(string email);
    }

}
