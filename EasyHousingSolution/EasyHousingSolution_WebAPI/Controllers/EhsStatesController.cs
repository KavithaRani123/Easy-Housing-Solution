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
    public class EhsStatesController : ControllerBase
    {
        private readonly EHSDBContext _context;

        public EhsStatesController(EHSDBContext context)
        {
            _context = context;
        }

        // GET: api/EhsStates
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EhsState>>> GetEhsStates()
        {
            return await _context.EhsStates.ToListAsync();
        }

        // GET: api/EhsStates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EhsState>> GetEhsState(int id)
        {
            var ehsState = await _context.EhsStates.FindAsync(id);

            if (ehsState == null)
            {
                return NotFound();
            }

            return ehsState;
        }

        // PUT: api/EhsStates/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEhsState(int id, EhsState ehsState)
        {
            if (id != ehsState.StateId)
            {
                return BadRequest();
            }

            _context.Entry(ehsState).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EhsStateExists(id))
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

        // POST: api/EhsStates
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EhsState>> PostEhsState(EhsState ehsState)
        {
            _context.EhsStates.Add(ehsState);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEhsState", new { id = ehsState.StateId }, ehsState);
        }

        // DELETE: api/EhsStates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EhsState>> DeleteEhsState(int id)
        {
            var ehsState = await _context.EhsStates.FindAsync(id);
            if (ehsState == null)
            {
                return NotFound();
            }

            _context.EhsStates.Remove(ehsState);
            await _context.SaveChangesAsync();

            return ehsState;
        }

        private bool EhsStateExists(int id)
        {
            return _context.EhsStates.Any(e => e.StateId == id);
        }
    }
}
