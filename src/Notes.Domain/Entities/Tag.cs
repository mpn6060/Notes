namespace Notes.Domain.Entities
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public ICollection<NoteTag> NoteTags { get; private set; } = new List<NoteTag>();
    }

    public class NoteTag
    {
        public System.Guid NoteId { get; set; }
        public Note Note { get; set; } = null!;
        public int TagId { get; set; }
        public Tag Tag { get; set; } = null!;
    }

    public class NoteVersion
    {
        public int Id { get; set; }
        public System.Guid NoteId { get; set; }
        public Note Note { get; set; } = null!;
        public string Content { get; set; } = string.Empty;
        public System.DateTime CreatedAt { get; set; } = System.DateTime.UtcNow;
    }
}
