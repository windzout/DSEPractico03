using EquipoProyectoTareaAPI.Data;
using EquipoProyectoTareaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class TareaController : ControllerBase
{
    private readonly MyDbContext _context;

    public TareaController(MyDbContext context)
    {
        _context = context;
    }

    // GET api/tarea
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Tarea>>> GetTareas()
    {
        return await _context.Tareas.ToListAsync();
    }

    // GET api/tarea/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Tarea>> GetTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);

        if (tarea == null)
        {
            return NotFound();
        }

        return tarea;
    }

    // POST api/tarea
    [HttpPost]
    public async Task<ActionResult<Tarea>> CreateTarea(Tarea tarea)
    {
        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
    }

    // POST api/proyecto/{id}/tareas
    [HttpPost("{id}/tareas")]
    public async Task<ActionResult<Tarea>> CreateTareaDeProyecto(int id, Tarea tarea)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        tarea.Proyecto = proyecto;
        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTarea), new { id = tarea.Id }, tarea);
    }

    // GET api/proyecto/{id}/tareas
    [HttpGet("{id}/tareas")]
    public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasDeProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        return await _context.Tareas.Where(t => t.Proyecto == proyecto).ToListAsync();
    }

    // PUT api/tarea/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Tarea>> UpdateTarea(int id, Tarea tarea)
    {
        var tareaExistente = await _context.Tareas.FindAsync(id);

        if (tareaExistente == null)
        {
            return NotFound();
        }

        tareaExistente.Nombre = tarea.Nombre;

        await _context.SaveChangesAsync();

        return tareaExistente;
    }

    // DELETE api/tarea/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteTarea(int id)
    {
        var tarea = await _context.Tareas.FindAsync(id);

        if (tarea == null)
        {
            return NotFound();
        }

        _context.Tareas.Remove(tarea);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}