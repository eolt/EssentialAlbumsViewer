using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtistsEssentialsApi.Models;
using System.Runtime.CompilerServices;

namespace ArtistsEssentialsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssentialAlbumsController : ControllerBase
    {
        private readonly EssentialsContext _context;

        public EssentialAlbumsController(EssentialsContext context)
        {
            _context = context;
        }

        // GET: api/EssentialAlbums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EssentialAlbum>>> GetEssentialAlbums()
        {
            return await _context.EssentialAlbums.ToListAsync();
        }

        // GET: api/EssentialAlbums/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EssentialAlbum>> GetEssentialAlbum(long id)
        {
            var essentialAlbum = await _context.EssentialAlbums.FindAsync(id);

            if (essentialAlbum == null)
            {
                return NotFound();
            }

            return essentialAlbum;
        }

        // PUT: api/EssentialAlbums/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEssentialAlbum(long id, EssentialAlbum essentialAlbum)
        {
            if (id != essentialAlbum.Id)
            {
                return BadRequest();
            }

            _context.Entry(essentialAlbum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EssentialAlbumExists(id))
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

        // POST: api/EssentialAlbums
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EssentialAlbum>> PostEssentialAlbum(EssentialAlbum essentialAlbum)
        {
            _context.EssentialAlbums.Add(essentialAlbum);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEssentialAlbum", new { id = essentialAlbum.Id }, essentialAlbum);
        }

        // DELETE: api/EssentialAlbums/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEssentialAlbum(long id)
        {
            var essentialAlbum = await _context.EssentialAlbums.FindAsync(id);
            if (essentialAlbum == null)
            {
                return NotFound();
            }

            _context.EssentialAlbums.Remove(essentialAlbum);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EssentialAlbumExists(long id)
        {
            return _context.EssentialAlbums.Any(e => e.Id == id);
        }
    }
}
