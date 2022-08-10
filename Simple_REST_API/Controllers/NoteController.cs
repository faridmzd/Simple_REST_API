using Microsoft.AspNetCore.Mvc;
using Simple_REST_API.Business;
using Simple_REST_API.Business.Services;
using Simple_REST_API.Domain;
using Simple_REST_API.Domain.Requests;
using Simple_REST_API.Domain.Responses;

namespace Simple_REST_API.Controllers
{
    [ApiController]
    public class NoteController : Controller
    {
        private readonly INoteService _noteService;
        
        public NoteController(INoteService noteService)
        {
            _noteService = noteService;
        }
        

        [HttpGet(ApiRoutes.Note.GetAll)]
        public async Task<IActionResult> GetNote()
        {
            var notes = await _noteService.GetNotesAsync();
            
            return Ok(notes);
        }
        
        [HttpGet(ApiRoutes.Note.Get)]
        public async Task<IActionResult> GetNote(Guid Id)
        {
            var note = await _noteService.GetNoteAsync(Id);
            
            if (note == null)   return NotFound();
            
            return Ok(note);
        }

        [HttpPost(ApiRoutes.Note.Add)]
        public async Task<IActionResult> AddNote([FromBody] CreateNoteRequest noteToCreate)
        {
            var note = new Note { Id = Guid.NewGuid(), Name = noteToCreate.Name, Content = noteToCreate.Content, 
                CreatedAt = DateTime.Now, EditedAt = DateTime.Now };

            await _noteService.CreateNoteAsync(note);


            var response = new CreateNoteResponse
            {
                Id = note.Id,
                Name = note.Name,
                Content = note.Content,
                CreatedAt = note.CreatedAt,
                EditedAt = note.EditedAt
            };


            return CreatedAtAction(nameof(GetNote), new { Id = response.Id },response);

        }

        [HttpPut(ApiRoutes.Note.Update)]
        public async Task<IActionResult> UpdateNote([FromRoute] Guid Id, [FromBody] UpdateNoteRequest noteToUpdate)
        {
            var note = await _noteService.GetNoteAsync(Id);

            if (note == null) return NotFound();

            note = new Note { Id = note.Id, Name = noteToUpdate.Name, Content = noteToUpdate.Content, CreatedAt = note.CreatedAt, EditedAt = DateTime.Now };

            var noteUpdated = await _noteService.UpdateNoteAsync(note);

            var response = new UpdateNoteResponse { Id = noteUpdated.Id, Name = noteUpdated.Name, Content = noteUpdated.Content, 
                CreatedAt = noteUpdated.CreatedAt, EditedAt = noteUpdated.EditedAt };

            return Ok(response);
        }
        
        [HttpDelete(ApiRoutes.Note.Delete)]
        public async Task<IActionResult> DeleteNote(Guid Id)
        {
            var note = await _noteService.GetNoteAsync(Id);

            if (note == null) return NotFound();

            await _noteService.DeleteNoteAsync(Id);

            return NoContent();
        }
    }
}
