using LibManEase.Application.DTOs;

namespace LibManEase.Application.Contracts.Services
{
    public interface IMemberService : IGenericService<MemberDto, CreateMemberDto, UpdateMemberDto>
    {
        Task<MemberDto> GetByEmailAsync(string email);
    }



}
