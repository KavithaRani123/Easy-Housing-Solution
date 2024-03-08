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
    public class EhsImagesController : ControllerBase
    {
        private readonly EHSDBContext _context;

        public EhsImagesController(EHSDBContext context)
        {
            _context = context;
        }

        // GET: api/EhsImages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EhsImage>>> GetEhsImages()
        {
            return await _context.EhsImages.ToListAsync();
        }

        // GET: api/EhsImages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EhsImage>> GetEhsImage(int id)
        {
            var ehsImage = await _context.EhsImages.FindAsync(id);

            if (ehsImage == null)
            {
                return NotFound();
            }

            return ehsImage;
        }

        // PUT: api/EhsImages/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEhsImage(int id, EhsImage ehsImage)
        {
            if (id != ehsImage.ImageId)
            {
                return BadRequest();
            }

            _context.Entry(ehsImage).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EhsImageExists(id))
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

        // POST: api/EhsImages
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<EhsImage>> PostEhsImage(EhsImage ehsImage)
        {
            _context.EhsImages.Add(ehsImage);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEhsImage", new { id = ehsImage.ImageId }, ehsImage);
        }

        // DELETE: api/EhsImages/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<EhsImage>> DeleteEhsImage(int id)
        {
            var ehsImage = await _context.EhsImages.FindAsync(id);
            if (ehsImage == null)
            {
                return NotFound();
            }

            _context.EhsImages.Remove(ehsImage);
            await _context.SaveChangesAsync();

            return ehsImage;
        }

        private bool EhsImageExists(int id)
        {
            return _context.EhsImages.Any(e => e.ImageId == id);
        }
    }
}
