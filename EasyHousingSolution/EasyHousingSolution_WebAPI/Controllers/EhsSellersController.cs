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
    public class EhsSellersController : ControllerBase
    {
        private readonly EHSDBContext _context;

        public EhsSellersController(EHSDBContext context)
        {
            _context = context;
        }

        // GET: api/EhsSellers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EhsSeller>>> GetEhsSellers()
        {
            return await _context.EhsSellers.ToListAsync();
        }

        // GET: api/EhsSellers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EhsSeller>> GetEhsSeller(int id)
        {
            var ehsSeller = await _context.EhsSellers.FindAsync(id);

            if (ehsSeller == null)
            {
                return NotFound();
            }

            return ehsSeller;
        }

        // PUT: api/EhsSellers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEhsSeller(int id, EhsSeller ehsSeller)
        {
            if (id != ehsSeller.SellerId)
            {
                return BadRequest();
            }

            _context.Entry(ehsSeller).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EhsSellerExists(id))
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

        // POST: api/EhsSellers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EhsSeller>> PostEhsSeller(EhsSeller ehsSeller)
        {
            _context.EhsSellers.Add(ehsSeller);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEhsSeller", new { id = ehsSeller.SellerId }, ehsSeller);
        }

        // DELETE: api/EhsSellers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EhsSeller>> DeleteEhsSeller(int id)
        {
            var ehsSeller = await _context.EhsSellers.FindAsync(id);
            if (ehsSeller == null)
            {
                return NotFound();
            }

            _context.EhsSellers.Remove(ehsSeller);
            await _context.SaveChangesAsync();

            return ehsSeller;
        }

        private bool EhsSellerExists(int id)
        {
            return _context.EhsSellers.Any(e => e.SellerId == id);
        }
    }
}
