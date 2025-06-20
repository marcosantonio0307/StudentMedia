using StudentMedia.Models;
using Microsoft.EntityFrameworkCore;

namespace StudentMedia.Data
{
    public interface IStudentService
    {
        Task<List<Student>> GetStudentsAsync();
        Task AddStudentAsync(Student student);
        Task<Student> GetStudentByIdAsync(int id);
        Task UpdateStudentAsync(Student student);
        Task DeleteStudentAsync(int id);
    }

    public class StudentService : IStudentService
    {
        private readonly AppDbContext _context;

        public StudentService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetStudentsAsync()
        {
            return await _context.Students.ToListAsync();
        }

        public async Task AddStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task UpdateStudentAsync(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudentAsync(int id)
        {
            var student = await GetStudentByIdAsync(id);
            if (student == null)
            {
                throw new KeyNotFoundException($"Student with ID {id} not found.");
            }

            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
