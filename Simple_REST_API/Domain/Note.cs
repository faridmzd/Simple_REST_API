﻿namespace Simple_REST_API.Domain
{
    public class Note
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime EditedAt { get; set; }

        public DateTime CreatedAt { get; set; }

    }
}
