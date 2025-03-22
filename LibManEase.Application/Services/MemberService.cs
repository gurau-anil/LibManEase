using AutoMapper;
using LibManEase.Application.Abstraction.Contracts.Logging;
using LibManEase.Application.Abstraction.Contracts.Services;
using LibManEase.Application.Abstraction.DTOs;
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;

namespace LibManEase.Application.Implementation.Services
{
    internal class MemberService : GenericService<Member, MemberDto, CreateMemberDto, UpdateMemberDto>, IMemberService
    {
        private readonly IMemberRepository _memberRepository;
        private readonly IAppLogger _logger;
        public MemberService(IMemberRepository memberRepository, IMapper mapper, IAppLogger logger)
            : base(memberRepository, mapper, logger)
        {
            _memberRepository = memberRepository;
            _logger = logger;
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
