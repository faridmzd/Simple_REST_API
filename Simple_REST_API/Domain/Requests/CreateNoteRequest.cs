namespace Simple_REST_API.Domain.Requests
{
    public class CreateNoteRequest
    {
        public string Name { get; set; } = null!;
        
        public string? Content { get; set; }
    }
}
