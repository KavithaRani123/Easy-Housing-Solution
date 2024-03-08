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
    public class EhsCartsController : ControllerBase
    {
        private readonly EHSDBContext _context;

        public EhsCartsController(EHSDBContext context)
        {
            _context = context;
        }

        // GET: api/EhsCarts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EhsCart>>> GetEhsCarts()
        {
            return await _context.EhsCarts.ToListAsync();
        }

        // GET: api/EhsCarts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EhsCart>> GetEhsCart(int id)
        {
            var ehsCart = await _context.EhsCarts.FindAsync(id);

            if (ehsCart == null)
            {
                return NotFound();
            }

            return ehsCart;
        }

        // PUT: api/EhsCarts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEhsCart(int id, EhsCart ehsCart)
        {
            if (id != ehsCart.CartId)
            {
                return BadRequest();
            }

            _context.Entry(ehsCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EhsCartExists(id))
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

        // POST: api/EhsCarts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EhsCart>> PostEhsCart(EhsCart ehsCart)
        {
            _context.EhsCarts.Add(ehsCart);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEhsCart", new { id = ehsCart.CartId }, ehsCart);
        }

        // DELETE: api/EhsCarts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EhsCart>> DeleteEhsCart(int id)
        {
            var ehsCart = await _context.EhsCarts.FindAsync(id);
            if (ehsCart == null)
            {
                return NotFound();
            }

            _context.EhsCarts.Remove(ehsCart);
            await _context.SaveChangesAsync();

            return ehsCart;
        }

        private bool EhsCartExists(int id)
        {
            return _context.EhsCarts.Any(e => e.CartId == id);
        }
    }
}
