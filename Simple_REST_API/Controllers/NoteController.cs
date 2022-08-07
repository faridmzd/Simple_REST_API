using Microsoft.AspNetCore.Mvc;
using Simple_REST_API.Domain;

namespace Simple_REST_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NoteController : Controller
    {
        private static List<Note> _notes = new List<Note>();

        public NoteController()
        {
            //if (_notes is null)
            //{
            //_notes = new List<Note>();
            //}
        }

        [HttpGet("note")]
        public IActionResult GetNote()
        {
            return Ok(_notes);
        }
        
        [HttpGet("note/{id:Guid}")]
        public IActionResult GetNote(Guid Id)
        {
            return Ok(_notes?.Where(note => note.Id == Id ));
        }

        [HttpPost("note")]
        public IActionResult AddNote([FromBody] Note note)
        {
            _notes.Add(note);
            return Ok(note);
        }

        [HttpPut("note")]
        public IActionResult UpdateNote([FromBody] Note note)
        {
            Note? wantedNote = _notes.FirstOrDefault(x => x.Id == note.Id);
            wantedNote = new Note { Id = (Guid)(wantedNote?.Id), Name = note?.Name, Content = note?.Content };

            return Ok(wantedNote);
        }
        
        [HttpDelete("note/{id:Guid}")]
        public IActionResult DeleteNote(Guid Id)
        {
            Note? wantedNote = _notes.FirstOrDefault(x => x.Id == Id);
            _notes.Remove(wantedNote);
            return Ok();
        }
    }
}
