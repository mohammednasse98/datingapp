using System.Diagnostics;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("api/[controller]")] //Locahost:5001/api/members
    [ApiController]
    public class MembersController(AppDbContext context) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<AppUser>>> GetMembers()
        {
            var members = await context.Users.ToListAsync();
            return members;
        }
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
