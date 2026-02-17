using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/today")]
public class TodayController : ControllerBase
{
    private readonly ApiContext _context;
    public TodayController(ApiContext context)
    {
        _context = context;
    }

    // GET: api/today
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Today>>> GetTodays()
    {
        var todays = _context.Todays;
        return await todays.ToListAsync();
    }

    // GET: api/today/1
    [HttpGet("{id}")]
    public async Task<ActionResult<Today>> GetToday(int id)
    {
        var today = await _context.Todays.SingleOrDefaultAsync(t => t.Id == id);
        if (today == null)
            return NotFound();
        return today;
    }

    // POST: api/today
    [HttpPost]
    public async Task<ActionResult<Today>> PostUoday(Today today)
    {
        _context.Todays.Add(today);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetToday), new { id = today.Id }, today);
    }

    // PUT: api/today/1
    [HttpPut("{id}")]
    public async Task<IActionResult> PutToday(int id, Today today)
    {
        if (id != today.Id)
            return BadRequest();
        _context.Entry(today).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Todays.Any(t => t.Id == id))
                return NotFound();
            else
                throw;
        }
        return NoContent();
    }

    // DELETE: api/today/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTodayItem(int id)
    {
        var today = await _context.Todays.FindAsync(id);
        if (today == null)
            return NotFound();
        _context.Todays.Remove(today);
        await _context.SaveChangesAsync();
        return NoContent();
    }

}