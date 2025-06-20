using StudentMedia.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentMedia.Data
{
    public interface IMatterService
    {
        Task AddMatterAsync(Matter matter);
        Task<List<Matter>> GetMattersAsync();
        Task<Matter?> GetMatterByIdAsync(int id);
        Task DeleteMatterAsync(int id);
        Task UpdateMatterAsync(Matter matter);
    }

    public class MatterService : IMatterService
    {
        private readonly AppDbContext _context;

        public MatterService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Matter>> GetMattersAsync()
        {
            return await _context.Matters.ToListAsync();
        }

        public async Task<Matter?> GetMatterByIdAsync(int id)
        {
            return await _context.Matters.FindAsync(id);
        }

        public async Task AddMatterAsync(Matter matter)
        {
            if (matter == null)
            {
                throw new ArgumentNullException(nameof(matter));
            }

            _context.Matters.Add(matter);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMatterAsync(int id)
        {
            var matter = await GetMatterByIdAsync(id);
            if (matter == null)
            {
                throw new KeyNotFoundException($"Matter with ID {id} not found.");
            }

            _context.Matters.Remove(matter);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateMatterAsync(Matter matter)
        {
            if (matter == null)
            {
                throw new ArgumentNullException(nameof(matter));
            }

            _context.Matters.Update(matter);
            await _context.SaveChangesAsync();
        }
    }
}