using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStudentBookRepository : IGenericRepository<StudentsBooks>
    {
        Task<StudentsBooks> AddSbooks(StudentsBooks entity);
        Task<List<StudentsBooks>> GetbooksById();
        Task<List<StudentsBooks>> GetBooksByStudentId(int id);

        void addStuBooks(List<StudentsBooks> items);

    }
}
