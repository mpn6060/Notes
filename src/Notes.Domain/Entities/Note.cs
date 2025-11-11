using System;

namespace Notes.Domain.Entities
{
    public class Note
    {
        public Guid Id { get; private set; } = Guid.NewGuid();
        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public bool IsPublic { get; private set; }
        public Priority Priority { get; private set; } = Priority.Medium;
        public string? UserId { get; set; }
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public void Update(string title, string content, bool isPublic, Priority priority)
        {
            if (string.IsNullOrWhiteSpace(title)) throw new ArgumentException("Title required", nameof(title));
            Title = title.Trim();
            Content = content ?? string.Empty;
            IsPublic = isPublic;
            Priority = priority;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
