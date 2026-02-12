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

        [HttpGet("all", Name = "GetAllNotes")]
        [SwaggerOperation(Summary = "Retorna todas as notas", OperationId = "GetAllNotes")]
        public async Task<IEnumerable<Notes>> Get()
        {
            return await _context.Notes.AsNoTracking().ToListAsync();
        }

        [HttpGet("{id}", Name = "GetNoteById")]
        [SwaggerOperation(Summary = "Retorna nota por id", OperationId = "GetNoteById")]
        public async Task<ActionResult<Notes>> GetById(Guid id)      
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
    }
}
