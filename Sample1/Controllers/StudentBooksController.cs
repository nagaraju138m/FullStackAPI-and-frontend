using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Repository;
using SampleData.Data;

namespace Sample1.Controllers
{
    public class StudentBooksController : Controller
    {
        private readonly StudentBookRepository studnetRepository;

        public StudentBooksController(StudentBookRepository studnetRepository)
        {
            this.studnetRepository = studnetRepository;
        }

        [HttpPost("StudentBooksAdd")]
        public async Task<ActionResult> AddBookToStudent(StudentsBooks studentsBooks)
        {
            if (studentsBooks == null)
            {
                return BadRequest(nameof(studentsBooks));
            }
            var Sbook = await studnetRepository.AddAsynch(studentsBooks);
            return Ok(studentsBooks);
        }
    }
}
