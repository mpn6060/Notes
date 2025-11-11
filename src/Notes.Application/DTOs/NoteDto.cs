using System;

namespace Notes.Application.DTOs
{
    public class NoteDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public bool IsPublic { get; set; }
    // Priority is represented as an integer (0=Low,1=Medium,2=High) in DTOs to avoid circular deps
    public int Priority { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
