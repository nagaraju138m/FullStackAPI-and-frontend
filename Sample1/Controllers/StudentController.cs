using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using SampleData.Data;
using System.Collections;
using System.Collections.Generic;

namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudnetRepository studnetRepository;

        public StudentController(IStudnetRepository studnetRepository)
        {
            this.studnetRepository = studnetRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable>> GetStudents()
        {
            var students = await studnetRepository.GetAllAsync();
            return Ok(students);
        }
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            if (student == null)
            {
                return BadRequest();
            }
            var students = await studnetRepository.AddAsynch(student);
            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateStudent(int id,Student student)
        {
            var stu = studnetRepository.GetAsync(id);
            if (stu == null)
            {
                return NotFound();
            }
            try
            {
                await studnetRepository.UpdateAsync(student);
            }
            catch (Exception ex) { }

            return Ok(student);
        }

    }
}
