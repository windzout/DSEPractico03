using EquipoProyectoTareaAPI.Data;
using EquipoProyectoTareaAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MiembroController : ControllerBase
{
    private readonly MyDbContext _context;

    public MiembroController(MyDbContext context)
    {
        _context = context;
    }

    // GET api/miembro
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Miembro>>> GetMiembros()
    {
        return await _context.Miembros.ToListAsync();
    }

    // GET api/miembro/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Miembro>> GetMiembro(int id)
    {
        var miembro = await _context.Miembros.FindAsync(id);

        if (miembro == null)
        {
            return NotFound();
        }

        return miembro;
    }

    // POST api/miembro
    [HttpPost]
    public async Task<ActionResult<Miembro>> CreateMiembro(Miembro miembro)
    {
        _context.Miembros.Add(miembro);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMiembro), new { id = miembro.Id }, miembro);
    }

    // POST api/equipo/{id}/miembros
    [HttpPost("{id}/miembros")]
    public async Task<ActionResult<Miembro>> CreateMiembroDeEquipo(int id, Miembro miembro)
    {
        var equipo = await _context.Equipos.FindAsync(id);

        if (equipo == null)
        {
            return NotFound();
        }

        miembro.EquipoId = equipo.Id;
        _context.Miembros.Add(miembro);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetMiembro), new { id = miembro.Id }, miembro);
    }

    // GET api/equipo/{id}/miembros
    [HttpGet("{id}/miembros")]
    public async Task<ActionResult<IEnumerable<Miembro>>> GetMiembrosDeEquipo(int id)
    {
        var equipo = await _context.Equipos.FindAsync(id);

        if (equipo == null)
        {
            return NotFound();
        }

        return await _context.Miembros.Where(m => m.EquipoId == equipo.Id).ToListAsync();
    }

    // PUT api/miembro/5
    [HttpPut("{id}")]
    public async Task<ActionResult<Miembro>> UpdateMiembro(int id, Miembro miembro)
    {
        var miembroExistente = await _context.Miembros.FindAsync(id);

        if (miembroExistente == null)
        {
            return NotFound();
        }

        miembroExistente.Nombre = miembro.Nombre;

        await _context.SaveChangesAsync();

        return miembroExistente;
    }

    // DELETE api/miembro/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteMiembro(int id)
    {
        var miembro = await _context.Miembros.FindAsync(id);

        if (miembro == null)
        {
            return NotFound();
        }

        _context.Miembros.Remove(miembro);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}