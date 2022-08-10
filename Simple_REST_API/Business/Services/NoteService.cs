using MongoDB.Driver;
using Simple_REST_API.Domain;

namespace Simple_REST_API.Business.Services
{
    public class NoteService : INoteService
    {

        private IMongoCollection<Note> collection;

        public NoteService()
        {

            var settings = MongoClientSettings.FromConnectionString("mongodb+srv://ferid:pfgFSAn7HRgeva5@cluster0.cuxmihl.mongodb.net/?retryWrites=true&w=majority");
            var client = new MongoClient(settings);
            var database = client.GetDatabase("NoteApp");
            collection = database.GetCollection<Note>("notes");

        }
        public async Task CreateNoteAsync(Note note)
        {
            await collection.InsertOneAsync(note);

        }

        public async Task DeleteNoteAsync(Guid id)
        {
            await collection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task<Note> GetNoteAsync(Guid id)
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
