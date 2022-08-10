using Simple_REST_API.Domain;

namespace Simple_REST_API.Business.Services
{
    public interface INoteService
    {
        Task CreateNoteAsync(Note note);
        
        Task<Note> GetNoteAsync(Guid id);
        
        Task<IEnumerable<Note>> GetNotesAsync();
        
        Task<Note> UpdateNoteAsync(Note note);
        
        Task DeleteNoteAsync(Guid id);
    }
}
