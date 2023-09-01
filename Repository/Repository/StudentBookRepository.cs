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
        private readonly StudendDbcontext context;

        public StudentBookRepository(StudendDbcontext context) : base(context)
        {
            this.context = context;
        }

        public async Task<StudentsBooks> AddSbooks(StudentsBooks entity)
        {
            var books = await context.studentsBooks.AddAsync(entity);
            await context.SaveChangesAsync();

            return (entity);
        }
    }
}
