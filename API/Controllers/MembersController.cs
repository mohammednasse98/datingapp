using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class MembersController(AppDbContext context) : BaseApiController
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }
        [Authorize]
        [HttpGet("{id}")] //Locahost:5001/api/members//mazola-id
        public async Task<ActionResult<AppUser>> GetMember(string id)
        {
            var members = context.Users.Find(id);

            if (members == null)
            {
            return NotFound();

            }
            else
            {
                return members;

            }

        }

    }
}
