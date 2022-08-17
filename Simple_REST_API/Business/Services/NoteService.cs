using MongoDB.Driver;
using Simple_REST_API.Domain;

namespace Simple_REST_API.Business.Services
{
    public class NoteService : INoteService
    {
        private readonly IMongoDatabase _database;
        private IMongoCollection<Note> collection;

        public NoteService(IMongoDatabase database)
        {
            _database = database;
            collection = database.GetCollection<Note>("notes");
        }
        public async Task CreateNoteAsync(Note note)
        {
            await collection.InsertOneAsync(note);

        }

        public async Task DeleteNoteAsync(string id)
        {
            await collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Note> GetNoteAsync(string id)
        {
            var note = (await collection.FindAsync(x => x.Id == id)).FirstOrDefault();

            return note;
        }
        
        public async Task<IEnumerable<Note>> GetNotesAsync()
        {
            return (await collection.FindAsync(x => true)).ToList();
        }

        public async Task<Note> UpdateNoteAsync(Note note)
        {
            return await collection.FindOneAndReplaceAsync<Note>(x => x.Id == note.Id, note, new FindOneAndReplaceOptions<Note> { ReturnDocument = ReturnDocument.After });
        }
    }
}
