using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkshopBooking.Data;
using WorkshopBooking.Models;

namespace WorkshopBooking.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkshopsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public WorkshopsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workshop>>> GetWorkshops()
    {
        return await _context.Workshops.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Workshop>> PostWorkshop(Workshop workshop)
    {
        _context.Workshops.Add(workshop);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWorkshops), new { id = workshop.ID }, workshop);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutWorkshop(int id, Workshop workshop)
    {
        if (id != workshop.ID)
        {
            return BadRequest("The ID is not correct");
        }
        _context.Entry(workshop).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Workshops.Any(e => e.ID == id))
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

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteWorkshop(int id)
    {
        var workshop = await _context.Workshops.FindAsync(id);

        if (workshop == null)
        {
            return NotFound();
        }

        _context.Workshops.Remove(workshop);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}