using LibManEase.Application.Contracts.Services;
using LibManEase.Application.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LibManEase.Api.Controllers
{
    public class MembersController : ApiControllerBase
    {
        private readonly IMemberService _memberService;

        public MembersController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberDto>>> GetAllMembers()
        {
            var members = await _memberService.GetAllAsync();
            return Ok(members);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MemberDto>> GetMember(int id)
        {
            var member = await _memberService.GetByIdAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }

        [HttpPost]
        public async Task<ActionResult<MemberDto>> CreateMember(CreateMemberDto createMemberDto)
        {
            var createdMember = await _memberService.CreateAsync(createMemberDto);
            return CreatedAtAction(nameof(GetMember), new { id = createdMember.Id }, createdMember);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberDto updateMemberDto)
        {
            if (id != updateMemberDto.Id)
            {
                return BadRequest();
            }

            await _memberService.UpdateAsync(updateMemberDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMember(int id)
        {
            await _memberService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<MemberDto>> GetMemberByEmail(string email)
        {
            var member = await _memberService.GetByEmailAsync(email);
            if (member == null)
            {
                return NotFound();
            }
            return Ok(member);
        }
    }
}
