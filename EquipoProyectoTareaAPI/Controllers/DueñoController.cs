using EquipoProyectoTareaAPI.Data;
using EquipoProyectoTareaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class DueñoController : ControllerBase
{
    private readonly MyDbContext _context;

    public DueñoController(MyDbContext context)
    {
        _context = context;
    }

    // GET api/dueño
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Dueño>>> GetDueños()
    {
        return await _context.Dueños.ToListAsync();
    }

    // GET api/dueño/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Dueño>> GetDueño(int id)
    {
        var dueño = await _context.Dueños.FindAsync(id);

        if (dueño == null)
        {
            return NotFound();
        }

        return dueño;
    }

    // POST api/dueño
    [HttpPost]
    public async Task<ActionResult<Dueño>> CreateDueño(Dueño dueño)
    {
        _context.Dueños.Add(dueño);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDueño), new { id = dueño.Id }, dueño);
    }

    // POST api/proyecto/{id}/dueños
    [HttpPost("{id}/dueños")]
    public async Task<ActionResult<Dueño>> CreateDueñoDeProyecto(int id, Dueño dueño)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        dueño.ProyectoId = proyecto.Id;
        _context.Dueños.Add(dueño);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetDueño), new { id = dueño.Id }, dueño);
    }

    // GET api/proyecto/{id}/dueños
    [HttpGet("{id}/dueños")]
    public async Task<ActionResult<IEnumerable<Dueño>>> GetDueñosDeProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        return await _context.Dueños.Where(d => d.ProyectoId == proyecto.Id).ToListAsync();
    }

    // PUT api/dueño/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Dueño>> UpdateDueño(int id, Dueño dueño)
    {
        var dueñoExistente = await _context.Dueños.FindAsync(id);

        if (dueñoExistente == null)
        {
            return NotFound();
        }

        dueñoExistente.Nombre = dueño.Nombre;

        await _context.SaveChangesAsync();

        return dueñoExistente;
    }

    // DELETE api/dueño/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteDueño(int id)
    {
        var dueño = await _context.Dueños.FindAsync(id);

        if (dueño == null)
        {
            return NotFound();
        }

        _context.Dueños.Remove(dueño);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}