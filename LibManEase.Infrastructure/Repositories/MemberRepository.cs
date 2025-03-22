
using LibManEase.Domain.Contracts;
using LibManEase.Domain.Entities;
using LibManEase.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace LibManEase.Infrastructure.Repositories
{
    internal class MemberRepository : Repository<Member, int>, IMemberRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MemberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Member> GetByEmailAsync(string email)
        {
            return await _dbContext.Members.FirstOrDefaultAsync(m => m.Email == email);
        }
    }

}

