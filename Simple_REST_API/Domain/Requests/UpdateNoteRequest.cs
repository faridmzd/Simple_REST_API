namespace Simple_REST_API.Domain.Requests
{
    public class UpdateNoteRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        
        public string Content { get; set; }
    }
}
