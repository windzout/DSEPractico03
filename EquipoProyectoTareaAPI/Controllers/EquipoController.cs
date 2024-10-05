using EquipoProyectoTareaAPI.Data;
using EquipoProyectoTareaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class EquipoController : ControllerBase
{
    private readonly MyDbContext _context;

    public EquipoController(MyDbContext context)
    {
        _context = context;
    }

    // GET api/equipo
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Equipo>>> GetEquipos()
    {
        return await _context.Equipos.ToListAsync();
    }

    // GET api/equipo/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Equipo>> GetEquipo(int id)
    {
        var equipo = await _context.Equipos.FindAsync(id);

        if (equipo == null)
        {
            return NotFound();
        }

        return equipo;
    }

    [HttpGet("{id}/proyectos")]
    public async Task<ActionResult<IEnumerable<Proyecto>>> GetProyectosDeEquipo(int id)
    {
        var equipo = await _context.Equipos.FindAsync(id);

        if (equipo == null)
        {
            return NotFound();
        }

        return await _context.Proyectos
            .Include(p => p.Equipo)
            .Where(p => p.Equipo.Id == id)
            .ToListAsync();
    }

    // POST api/equipo
    [HttpPost]
    public async Task<ActionResult<Equipo>> CreateEquipo(Equipo equipo)
    {
        _context.Equipos.Add(equipo);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetEquipo), new { id = equipo.Id }, equipo);
    }

    [HttpPost("{id}/proyectos")]
    public async Task<ActionResult<Proyecto>> CreateProyectoDeEquipo(int id, Proyecto proyecto)
    {
        var equipo = await _context.Equipos.FindAsync(id);

        if (equipo == null)
        {
            return NotFound();
        }

        proyecto.Equipo = equipo;
        _context.Proyectos.Add(proyecto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetProyectosDeEquipo), new { id = equipo.Id }, proyecto);
    }

    // PUT api/equipo/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Equipo>> UpdateEquipo(int id, Equipo equipo)
    {
        var equipoExistente = await _context.Equipos.FindAsync(id);

        if (equipoExistente == null)
        {
            return NotFound();
        }

        equipoExistente.Nombre = equipo.Nombre;

        await _context.SaveChangesAsync();

        return equipoExistente;
    }

    // DELETE api/equipo/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEquipo(int id)
    {
        var equipo = await _context.Equipos.FindAsync(id);

        if (equipo == null)
        {
            return NotFound();
        }

        _context.Equipos.Remove(equipo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}