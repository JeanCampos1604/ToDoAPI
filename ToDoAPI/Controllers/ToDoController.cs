using Microsoft.AspNetCore.Mvc;
using ToDoAPI.Data;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Annotations;

namespace ToDoAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private readonly ToDoContext _context;

        public ToDoController(ToDoContext context) => _context = context;

        #region MyRegion
        [HttpGet("all", Name = "GetAllNotes")]
        [SwaggerOperation(Summary = "Retorna todas as notas", OperationId = "GetAllNotes")]
        public async Task<IEnumerable<Notes>> Get()
        {
            return await _context.Notes.AsNoTracking().ToListAsync();
        }
        #endregion

        [HttpGet("{id}", Name = "GetNoteById")]
        [SwaggerOperation(Summary = "Retorna nota por id", OperationId = "GetNoteById")]
        public async Task<ActionResult<Notes>> GetById(string id)      
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null) return NotFound();
            return note;
        }

        [HttpPost(Name = "CreateNote")]
        [SwaggerOperation(Summary = "Cria uma nova nota", OperationId = "CreateNote")]
        public async Task<ActionResult<Notes>> Create([FromBody] Notes note)
        {
            if (note == null) return BadRequest();

            note.Id = Guid.NewGuid().ToString();
            note.CreatedAt = DateTime.UtcNow;
            note.UpdatedAt = DateTime.UtcNow;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetNoteById", new { id = note.Id }, note);
        }

        [HttpDelete("{id}", Name = "DeleteNoteById")]
        [SwaggerOperation(Summary = "Exclui nota por id", OperationId = "DeleteNoteById")]
        public async Task<ActionResult<Notes>> DeleteById(string id)
        {
            _context.Notes.Remove(new Notes { Id = id.ToString() });
            await _context.SaveChangesAsync();
            return NoContent();
        }

        /*
        [HttpPost(Name = "UpdateNote")]
        [SwaggerOperation(Summary = "Atualiza uma nota", OperationId = "UpdateNote")]
        public async Task<ActionResult<Notes>> Put([FromBody] Notes note, string id)
        {
            if (note == null) return BadRequest();

            note.Id = id;
            note.CreatedAt = DateTime.UtcNow;
            note.UpdatedAt = DateTime.UtcNow;

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();

            return CreatedAtRoute("GetNoteById", new { id = note.Id }, note);
        }
        */
    }
}
