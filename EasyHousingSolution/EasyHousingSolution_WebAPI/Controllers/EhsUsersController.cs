using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EasyHousingSolution_WebAPI.Model;

namespace EasyHousingSolution_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EhsUsersController : ControllerBase
    {
        private readonly EHSDBContext _context;

        public EhsUsersController(EHSDBContext context)
        {
            _context = context;
        }

        // GET: api/EhsUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EhsUser>>> GetEhsUsers()
        {
            return await _context.EhsUsers.ToListAsync();
        }

        // GET: api/EhsUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EhsUser>> GetEhsUser(string id)
        {
            var ehsUser = await _context.EhsUsers.FindAsync(id);

            if (ehsUser == null)
            {
                return NotFound();
            }

            return ehsUser;
        }

        // PUT: api/EhsUsers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEhsUser(string id, EhsUser ehsUser)
        {
            if (id != ehsUser.UserName)
            {
                return BadRequest();
            }

            _context.Entry(ehsUser).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EhsUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/EhsUsers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EhsUser>> PostEhsUser(EhsUser ehsUser)
        {
            _context.EhsUsers.Add(ehsUser);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EhsUserExists(ehsUser.UserName))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEhsUser", new { id = ehsUser.UserName }, ehsUser);
        }

        // DELETE: api/EhsUsers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EhsUser>> DeleteEhsUser(string id)
        {
            var ehsUser = await _context.EhsUsers.FindAsync(id);
            if (ehsUser == null)
            {
                return NotFound();
            }

            _context.EhsUsers.Remove(ehsUser);
            await _context.SaveChangesAsync();

            return ehsUser;
        }

        private bool EhsUserExists(string id)
        {
            return _context.EhsUsers.Any(e => e.UserName == id);
        }
    }
}
