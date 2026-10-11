using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client.NativeInterop;
using Student.API.Controllers.Model;

namespace Student.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowFrontendApp")]
    public class StudentController : ControllerBase
    {
        private readonly StudentDbContext _studentDbContext;
       public StudentController(StudentDbContext studentDbContext)
        {
            _studentDbContext= studentDbContext;

        }

        [HttpGet]
        public IActionResult GetStudents()
        {
            var studentList=_studentDbContext.Students.ToList();
            return Ok(studentList);
        }

        [HttpPost]
        public  IActionResult SaveStudent(Model.Student student)
        {
            student.StudId = 0;
            _studentDbContext.Students.Add(student);
             _studentDbContext.SaveChanges();
            return Ok(student);
        }

        [HttpPut]
        public IActionResult UpdateStudent(Model.Student student)
        {
            var existingRecord = _studentDbContext.Students.Find(student.StudId);
            if (existingRecord != null)
            {
                existingRecord.StudName = student.StudName;
                existingRecord.Email = student.Email;
                existingRecord.City = student.City;
                existingRecord.State = student.State;
                existingRecord.Pincode = student.Pincode;
                existingRecord.Address1 = student.Address1;
                existingRecord.Address2 = student.Address2;
                return Ok(student);
            }
            else
            {
                return NotFound();
            }
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var record = _studentDbContext.Students.Find(id);
            if (record!=null)
            {
                _studentDbContext.Students.Remove(record);
                _studentDbContext.SaveChanges();
                return Ok(record);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
