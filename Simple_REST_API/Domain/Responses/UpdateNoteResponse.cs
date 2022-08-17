namespace Simple_REST_API.Domain.Responses
{
    public class UpdateNoteResponse
    {
        public string Id { get; set; } = null!;
        
        public string? Name { get; set; }
        
        public string? Content { get; set; }

        public DateTime EditedAt { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
