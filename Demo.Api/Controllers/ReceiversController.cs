using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Demo.Api.Data;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiversController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceiversController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Receivers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receiver>>> GetReceivers()
        {
          if (_context.Receivers == null)
          {
              return NotFound();
          }
            return await _context.Receivers.ToListAsync();
        }

        // GET: api/Receivers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receiver>> GetReceiver(long id)
        {
          if (_context.Receivers == null)
          {
              return NotFound();
          }
            var receiver = await _context.Receivers.FindAsync(id);

            if (receiver == null)
            {
                return NotFound();
            }

            return receiver;
        }

        // PUT: api/Receivers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceiver(long id, Receiver receiver)
        {
            if (id != receiver.Id)
            {
                return BadRequest();
            }

            _context.Entry(receiver).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiverExists(id))
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

        // POST: api/Receivers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Receiver>> PostReceiver(Receiver receiver)
        {
          if (_context.Receivers == null)
          {
              return Problem("Entity set 'AppDbContext.Receivers'  is null.");
          }
            _context.Receivers.Add(receiver);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceiver", new { id = receiver.Id }, receiver);
        }

        // DELETE: api/Receivers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceiver(long id)
        {
            if (_context.Receivers == null)
            {
                return NotFound();
            }
            var receiver = await _context.Receivers.FindAsync(id);
            if (receiver == null)
            {
                return NotFound();
            }

            _context.Receivers.Remove(receiver);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceiverExists(long id)
        {
            return (_context.Receivers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
