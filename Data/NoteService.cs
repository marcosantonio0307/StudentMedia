using StudentMedia.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentMedia.Data
{
    public interface INoteService
    {
        Task AddNoteAsync(Note note);
        Task<List<Note>> GetNotesAsync();
        Task<Note?> GetNoteByIdAsync(int id);
        Task DeleteNoteAsync(int id);
        Task UpdateNoteAsync(Note note);
    }

    public class NoteService : INoteService
    {
        private readonly AppDbContext _context;

        public NoteService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Note>> GetNotesAsync()
        {
            return await _context.Notes.ToListAsync();
        }

        public async Task<Note?> GetNoteByIdAsync(int id)
        {
            return await _context.Notes.FindAsync(id);
        }

        public async Task AddNoteAsync(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Notes.Add(note);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteNoteAsync(int id)
        {
            var note = await GetNoteByIdAsync(id);
            if (note == null)
            {
                throw new KeyNotFoundException($"Note with ID {id} not found.");
            }

            _context.Notes.Remove(note);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateNoteAsync(Note note)
        {
            if (note == null)
            {
                throw new ArgumentNullException(nameof(note));
            }

            _context.Notes.Update(note);
            await _context.SaveChangesAsync();
        }
    }
}