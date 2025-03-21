using LibManEase.Domain.Contracts.Base;
using LibManEase.Domain.Entities;

namespace LibManEase.Domain.Contracts
{
    // Domain/Contracts/IMemberRepository.cs
    public interface IMemberRepository : IRepository<Member, int>
    {
        Task<Member> GetByEmailAsync(string email);
    }

}
