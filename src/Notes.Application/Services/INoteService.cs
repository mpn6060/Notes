using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Notes.Application.DTOs;
// Priority is represented as int in requests (0=Low,1=Medium,2=High)

namespace Notes.Application.Services
{
    public interface INoteService
    {
        Task<IEnumerable<NoteDto>> GetNotesAsync(string? userId = null);
        Task<NoteDto?> GetNoteAsync(Guid id, string? userId = null);
        Task<NoteDto> CreateNoteAsync(CreateNoteRequest req, string? userId = null);
        Task<bool> UpdateNoteAsync(UpdateNoteRequest req, string? userId = null);
        Task<bool> DeleteNoteAsync(Guid id, string? userId = null);
    }

    public record CreateNoteRequest(string Title, string Content, bool IsPublic, int Priority);
    public record UpdateNoteRequest(Guid Id, string Title, string Content, bool IsPublic, int Priority);
}
