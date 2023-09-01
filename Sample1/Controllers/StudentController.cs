﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using SampleData.CustomModals;
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
        private readonly IMapper mapper;

        public StudentController(IStudnetRepository studnetRepository, IMapper mapper)
        {
            this.studnetRepository = studnetRepository;
            this.mapper = mapper;
        }

        [HttpGet("GetStudents")]
        public async Task<ActionResult<IEnumerable>> GetStudents()
        {
            var students = await studnetRepository.GetAllAsync();
            var studentDto = mapper.Map<List<GetStudentsDto>>(students);
            return Ok(studentDto);
        }
        
        [HttpPost("PostStudent")]
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
            try
            {
                await studnetRepository.UpdateAsync(id,student);
            }
            catch (Exception ex) { }

            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                await studnetRepository.DeleteAsync(id);
            }
            catch (Exception ex) { }

            return Ok(id);
        }

        [HttpPost("StudentBooksAdd")]
        public async Task<ActionResult> AddBookToStudent(StudentsBooks studentsBooks)
        {
            if (studentsBooks == null)
            {
                return BadRequest(nameof(studentsBooks));
            }
            var Sbook = await studnetRepository.AddSbooks(studentsBooks);
            return Ok(studentsBooks);
        }

        [HttpGet("getAllStudentBooks")]
        public async Task<ActionResult<IEnumerable>> GetStudentsBooks()
        {
            var studentbooks = await studnetRepository.allSbooks();

            return Ok(studentbooks);
        }
    }

}
