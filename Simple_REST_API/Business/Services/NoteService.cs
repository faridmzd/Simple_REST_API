using Simple_REST_API.Domain;

namespace Simple_REST_API.Business.Services
{
    public class NoteService : INoteService
    {
        private List<Note> notes;

        public NoteService()
        {
            notes = new List<Note>();
        }
        public async Task<Note> CreateNoteAsync(Note note)
        {
            notes.Add(note);

            return await Task.FromResult(note);
        }

        public async Task DeleteNoteAsync(Guid id)
        {
            await Task.Run(() => { var index = notes.FindIndex(x => x.Id == id); notes.RemoveAt(index);  });
        }

        public async Task<Note> GetNoteAsync(Guid id)
        {
            return await Task.Run(() => { return notes.FirstOrDefault(x => x.Id == id); } );
        }
        
        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return  await Task.FromResult((IEnumerable<Note>)notes);
        }

        public async Task<Note> UpdateNoteAsync(Note note)
        {
           return await Task.Run( () =>
            {
                var noteToUpdate = notes.FirstOrDefault(x => x.Id == note.Id);

                noteToUpdate = note;

                return noteToUpdate;
            }
            );

        }
    }
}
