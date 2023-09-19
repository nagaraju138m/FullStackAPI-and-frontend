using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using Repository.Repository;
using SampleData.Data;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using SampleData.Data;
using System.Collections;
namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBooksController : Controller
    {
        private readonly IStudentBookRepository studnetRepository;

        public StudentBooksController(IStudentBookRepository studnetRepository)
        {
            this.studnetRepository = studnetRepository;
        }

        [HttpPost("StudentBooksAdd")]
        public async Task<ActionResult> AddBookToStudent([FromBody] List<StudentsBooks> studentsBooks)


        {
            if (studentsBooks == null)
            {
                return BadRequest(nameof(studentsBooks));
            }
            studnetRepository.addStuBooks(studentsBooks);
            return Ok(studentsBooks);
        }

        [HttpGet("getByStuId")]
        public async Task<ActionResult> getByStuId(int sId)
        {
            if (sId < 0)
            {
                return BadRequest(nameof(sId));
            }

            var sbook = await studnetRepository.GetBooksByStudentId(sId);
            return Ok(sbook);
        }

  

    }
}
