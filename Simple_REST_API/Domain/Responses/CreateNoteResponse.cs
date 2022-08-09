namespace Simple_REST_API.Domain.Responses
{
    public class CreateNoteResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string Content { get; set; }
    }
}
