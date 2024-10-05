using EquipoProyectoTareaAPI.Data;
using EquipoProyectoTareaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class ProyectoController : ControllerBase
{
    private readonly MyDbContext _context;

    public ProyectoController(MyDbContext context)
    {
        _context = context;
    }

    // GET api/proyecto
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectos()
    {
        return await _context.Proyectos.ToListAsync();
    }

    // GET api/proyecto/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Proyecto>> GetProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        return proyecto;
    }

    [HttpGet("{id}/tareas")]
    public async Task<ActionResult<IEnumerable<Tarea>>> GetTareasDeProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        return await _context.Tareas.Where(t => t.ProyectoId == id).ToListAsync();
    }


    // POST api/proyecto
    [HttpPost]
    public async Task<ActionResult<Proyecto>> CreateProyecto(Proyecto proyecto)
    {
        _context.Proyectos.Add(proyecto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProyecto), new { id = proyecto.Id }, proyecto);
    }

    [HttpPost("{id}/tareas")]
    public async Task<ActionResult<Tarea>> CreateTareaDeProyecto(int id, Tarea tarea)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        tarea.ProyectoId = id;
        _context.Tareas.Add(tarea);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetTareasDeProyecto), new { id = proyecto.Id }, tarea);
    }

    // PUT api/proyecto/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Proyecto>> UpdateProyecto(int id, Proyecto proyecto)
    {
        var proyectoExistente = await _context.Proyectos.FindAsync(id);

        if (proyectoExistente == null)
        {
            return NotFound();
        }

        proyectoExistente.Nombre = proyecto.Nombre;

        await _context.SaveChangesAsync();

        return proyectoExistente;
    }

    // DELETE api/proyecto/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteProyecto(int id)
    {
        var proyecto = await _context.Proyectos.FindAsync(id);

        if (proyecto == null)
        {
            return NotFound();
        }

        _context.Proyectos.Remove(proyecto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}