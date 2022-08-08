using Microsoft.AspNetCore.Mvc;
using Simple_REST_API.Business;
using Simple_REST_API.Domain;

namespace Simple_REST_API.Controllers
{
    [ApiController]
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

        [HttpGet(ApiRoutes.Note.GetAll)]
        public IActionResult GetNote()
        {
            return Ok(_notes);
        }
        
        [HttpGet(ApiRoutes.Note.Get)]
        public IActionResult GetNote(Guid Id)
        {
            return Ok(_notes?.Where(note => note.Id == Id ));
        }

        [HttpPost(ApiRoutes.Note.Add)]
        public IActionResult AddNote([FromBody] Note note)
        {
            _notes.Add(note);
            return Ok(note);
        }

        [HttpPut(ApiRoutes.Note.Update)]
        public IActionResult UpdateNote([FromBody] Note note)
        {
            Note? wantedNote = _notes.FirstOrDefault(x => x.Id == note.Id);
            wantedNote = new Note { Id = (Guid)(wantedNote?.Id), Name = note?.Name, Content = note?.Content };

            return Ok(wantedNote);
        }
        
        [HttpDelete(ApiRoutes.Note.Delete)]
        public IActionResult DeleteNote(Guid Id)
        {
            Note? wantedNote = _notes.FirstOrDefault(x => x.Id == Id);
            _notes.Remove(wantedNote);
            return Ok();
        }
    }
}
