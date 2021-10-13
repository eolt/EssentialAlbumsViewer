using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ArtistsEssentialsApi.Models;
using System.Security.Cryptography.X509Certificates;

namespace ArtistsEssentialsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EssentialArtistsController : ControllerBase
    {
        private readonly EssentialsContext _context;

        public EssentialArtistsController(EssentialsContext context)
        {
            _context = context;
        }

        // GET: api/EssentialArtists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EssentialArtist>>> GetEssentialArtists(string genre)
        {
            if(String.IsNullOrEmpty(genre))
                return await _context.EssentialArtists.ToListAsync();
            else
            {
                var essentialArtist = await _context.EssentialArtists.Where(x => x.Genre == genre).ToListAsync();

                if (essentialArtist == null)
                {
                    return NotFound();
                }

                return essentialArtist;
            }
        }

        // GET: api/EssentialArtists/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EssentialArtist>> GetEssentialArtist(long id)
        {
            var essentialArtist = await _context.EssentialArtists
                .Include(x => x.EssentialAlbums)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (essentialArtist == null)
            {
                return NotFound();
            }

            return essentialArtist;
        }

        // PUT: api/EssentialArtists/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEssentialArtist(long id, EssentialArtist essentialArtist)
        {
            if (id != essentialArtist.Id)
            {
                return BadRequest();
            }

            _context.Entry(essentialArtist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EssentialArtistExists(id))
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

        // POST: api/EssentialArtists
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EssentialArtist>> PostEssentialArtist(EssentialArtist essentialArtist)
        {
            _context.EssentialArtists.Add(essentialArtist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEssentialArtist", new { id = essentialArtist.Id }, essentialArtist);
        }

        // DELETE: api/EssentialArtists/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEssentialArtist(long id)
        {
            var essentialArtist = await _context.EssentialArtists.FindAsync(id);
            if (essentialArtist == null)
            {
                return NotFound();
            }

            _context.EssentialArtists.Remove(essentialArtist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EssentialArtistExists(long id)
        {
            return _context.EssentialArtists.Any(e => e.Id == id);
        }
    }
}
