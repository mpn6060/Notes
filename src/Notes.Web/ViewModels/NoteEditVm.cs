using System.ComponentModel.DataAnnotations;

namespace Notes.Web.ViewModels
{
    public class NoteEditVm
    {
        public Guid? Id { get; set; }

        [Required, StringLength(150)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Content { get; set; } = string.Empty;

        public bool IsPublic { get; set; }

    // 0 = Low, 1 = Medium, 2 = High
    public int Priority { get; set; } = 1;
    }

    public class NoteListVm
    {
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string? Excerpt { get; set; }
    public int Priority { get; set; } = 1;
    }
}
