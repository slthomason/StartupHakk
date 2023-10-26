using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEBAPIDemo.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPIDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
       private readonly IStudentRespository _repo;

        public StudentController(IStudentRespository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Student>> GetValues()
        {
            var students =  _repo.Get();
            return Ok(students);
        }

        public async Task<ActionResult> Post([FromBody] Student student)
        {
            if(student == null)
            {
                return NotFound("Getting null for student");
            }
            _repo.Post(student);
            return Ok("Value Added");
        }

        [HttpPut]
        public  async Task<ActionResult> Update([FromBody] Student student)
        {
            if (student == null)
            {
                return NotFound("Getting null for student");
            }

            _repo.Update(student);
            return Ok("Value Updated");
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound("Getting null for student id");
            }
            _repo.Delete(id);
            return Ok("Value Deleted");
        }
    }
}
