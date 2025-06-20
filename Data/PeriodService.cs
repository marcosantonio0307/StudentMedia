using StudentMedia.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentMedia.Data
{
    public interface IPeriodService
    {
        Task AddPeriodAsync(Period period);
        Task<List<Period>> GetPeriodsAsync();
        Task<Period?> GetPeriodByIdAsync(int id);
        Task DeletePeriodAsync(int id);
        Task UpdatePeriodAsync(Period period);
    }

    public class PeriodService : IPeriodService
    {
        private readonly AppDbContext _context;

        public PeriodService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Period>> GetPeriodsAsync()
        {
            return await _context.Periods.ToListAsync();
        }

        public async Task<Period?> GetPeriodByIdAsync(int id)
        {
            return await _context.Periods.FindAsync(id);
        }

        public async Task AddPeriodAsync(Period period)
        {
            if (period == null)
            {
                throw new ArgumentNullException(nameof(period));
            }

            _context.Periods.Add(period);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePeriodAsync(int id)
        {
            var period = await GetPeriodByIdAsync(id);
            if (period == null)
            {
                throw new KeyNotFoundException($"Period with ID {id} not found.");
            }

            _context.Periods.Remove(period);
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePeriodAsync(Period period)
        {
            if (period == null)
            {
                throw new ArgumentNullException(nameof(period));
            }

            _context.Periods.Update(period);
            await _context.SaveChangesAsync();
        }
    }
}