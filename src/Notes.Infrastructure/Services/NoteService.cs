using Microsoft.EntityFrameworkCore;
using Notes.Application.DTOs;
using Notes.Application.Services;
using Notes.Domain.Entities;
using Notes.Infrastructure.Persistence;

namespace Notes.Infrastructure.Services
{
    public class NoteService : INoteService
    {
        private readonly NotesDbContext _db;
        public NoteService(NotesDbContext db) => _db = db;

        public async Task<IEnumerable<NoteDto>> GetNotesAsync(string? userId = null)
        {
            var q = _db.Notes.AsQueryable();
            if (!string.IsNullOrEmpty(userId)) q = q.Where(n => n.UserId == userId);
            return await q.OrderByDescending(n => n.UpdatedAt)
                .Select(n => new NoteDto
                {
                    Id = n.Id,
                    Title = n.Title,
                    Content = n.Content,
                    IsPublic = n.IsPublic,
                    Priority = (int)n.Priority,
                    UpdatedAt = n.UpdatedAt
                }).ToListAsync();
        }

        public async Task<NoteDto?> GetNoteAsync(Guid id, string? userId = null)
        {
            var n = await _db.Notes
                .FirstOrDefaultAsync(x => x.Id == id && (userId == null || x.UserId == userId));
            if (n == null) return null;
            return new NoteDto { Id = n.Id, Title = n.Title, Content = n.Content, IsPublic = n.IsPublic, Priority = (int)n.Priority, UpdatedAt = n.UpdatedAt };
        }

        public async Task<NoteDto> CreateNoteAsync(CreateNoteRequest req, string? userId = null)
        {
            var note = new Note();
            note.Update(req.Title, req.Content, req.IsPublic, (Priority)req.Priority);
            note.UserId = userId;

            _db.Notes.Add(note);
            await _db.SaveChangesAsync();

            return new NoteDto { Id = note.Id, Title = note.Title, Content = note.Content, IsPublic = note.IsPublic, Priority = (int)note.Priority, UpdatedAt = note.UpdatedAt };
        }

        public async Task<bool> UpdateNoteAsync(UpdateNoteRequest req, string? userId = null)
        {
            var note = await _db.Notes
                .FirstOrDefaultAsync(n => n.Id == req.Id && (userId == null || n.UserId == userId));
            if (note == null) return false;

            note.Update(req.Title, req.Content, req.IsPublic, (Priority)req.Priority);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteNoteAsync(Guid id, string? userId = null)
        {
            var note = await _db.Notes.FirstOrDefaultAsync(n => n.Id == id && (userId == null || n.UserId == userId));
            if (note == null) return false;
            _db.Notes.Remove(note);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
