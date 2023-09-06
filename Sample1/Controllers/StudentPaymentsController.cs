using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repository.Interfaces;
using SampleData.Data;

namespace Sample1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentPaymentsController : ControllerBase
    {
        private readonly IStudentPayments studentPayments;
        private readonly IMapper mapper;

        public StudentPaymentsController(IStudentPayments studentPayments, IMapper mapper)
        {
            this.studentPayments = studentPayments;
            this.mapper = mapper;
        }

        [HttpGet("GetStuPayments")]
        public async Task<ActionResult<StudentPayments>> GetStuPayments()
        {
            var allPayments = await studentPayments.GetAllAsync();
            return Ok(allPayments);
        }

        [HttpGet("GetStuPayment")]
        public async Task<ActionResult<StuPayments>> getStuPayment(int id)
        {
            var payments = await studentPayments.GetStuPayment(id);

            return Ok(payments);
        }

        [HttpPost("PostStuPayment")]
        public async Task<ActionResult<StudentPayments>> PostStuPayment(StudentPayments studentPayment)
        {
            if (studentPayment == null)
            {
                return BadRequest();
            }
            var payment = await studentPayments.AddAsynch(studentPayment);
            return Ok(payment);
        }


    }
}
