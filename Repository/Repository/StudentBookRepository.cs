using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using SampleData;
using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class StudentBookRepository : GenericRepository<StudentsBooks>, IStudentBookRepository
    {
        private readonly StudendDbcontext _context;

        public StudentBookRepository(StudendDbcontext contexts) : base(contexts)
        {
            this._context = contexts;
        }

        public async Task<StudentsBooks> AddSbooks(StudentsBooks entity)
        {
            var books = await _context.studentsBooks.AddAsync(entity);
            await _context.SaveChangesAsync();

            return (entity);
        }
        public async Task<List<StudentsBooks>> GetBooksByStudentId(int studentId)
        {
            var books = await _context.studentsBooks.Where(sb => sb.studentId == studentId).ToListAsync();

            return books;
        }

        public async Task<List<StudentsBooks>> GetbooksById()
        {

            throw new NotImplementedException();
        }
        public void addStuBooks(List<StudentsBooks> studentsBooks)
        {
            foreach (var book in studentsBooks)
            {
                 this._context.studentsBooks.Add(book);
                 _context.SaveChangesAsync();
            }
        }
    }
}
