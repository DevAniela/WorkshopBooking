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
}