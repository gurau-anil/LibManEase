using AutoMapper;
using LibManEase.Application.Contracts.Services;
using LibManEase.Application.DTOs;
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;

namespace LibManEase.Application.Services
{
    public class MemberService : GenericService<Member, MemberDto, CreateMemberDto, UpdateMemberDto>, IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository, IMapper mapper)
            : base(memberRepository, mapper)
        {
            _memberRepository = memberRepository;
        }

        public async Task<MemberDto> GetByEmailAsync(string email)
        {
            var member = await _memberRepository.GetByEmailAsync(email);
            if (member == null)
                throw new InvalidOperationException("Member not found.");

            return _mapper.Map<MemberDto>(member);
        }
    }

}
