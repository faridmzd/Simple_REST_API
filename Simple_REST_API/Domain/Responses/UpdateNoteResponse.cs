﻿namespace Simple_REST_API.Domain.Response
{
    public class UpdateNoteResponse
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Content { get; set; }
    }
}