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
    public class EhsBuyersController : ControllerBase
    {
        private readonly EHSDBContext _context;

        public EhsBuyersController(EHSDBContext context)
        {
            _context = context;
        }

        // GET: api/EhsBuyers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EhsBuyer>>> GetEhsBuyers()
        {
            return await _context.EhsBuyers.ToListAsync();
        }

        // GET: api/EhsBuyers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EhsBuyer>> GetEhsBuyer(int id)
        {
            var ehsBuyer = await _context.EhsBuyers.FindAsync(id);

            if (ehsBuyer == null)
            {
                return NotFound();
            }

            return ehsBuyer;
        }

        // PUT: api/EhsBuyers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEhsBuyer(int id, EhsBuyer ehsBuyer)
        {
            if (id != ehsBuyer.BuyerId)
            {
                return BadRequest();
            }

            _context.Entry(ehsBuyer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EhsBuyerExists(id))
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

        // POST: api/EhsBuyers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EhsBuyer>> PostEhsBuyer(EhsBuyer ehsBuyer)
        {
            _context.EhsBuyers.Add(ehsBuyer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEhsBuyer", new { id = ehsBuyer.BuyerId }, ehsBuyer);
        }

        // DELETE: api/EhsBuyers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EhsBuyer>> DeleteEhsBuyer(int id)
        {
            var ehsBuyer = await _context.EhsBuyers.FindAsync(id);
            if (ehsBuyer == null)
            {
                return NotFound();
            }

            _context.EhsBuyers.Remove(ehsBuyer);
            await _context.SaveChangesAsync();

            return ehsBuyer;
        }

        private bool EhsBuyerExists(int id)
        {
            return _context.EhsBuyers.Any(e => e.BuyerId == id);
        }
    }
}
