using LoggingWithSerilog.Model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Reflection.Metadata.Ecma335;

namespace LoggingWithSerilog.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly ILogger<StudentController> logger;

        public StudentController(ILogger<StudentController> logger)
        {
            this.logger = logger;
        }

        [HttpGet(Name = "GetStudent")]
        public IEnumerable<Student> Get()
        {
            //if (1 != 2)
            //{
            //    throw new Exception("Failed to retrieve data");
            //}
            var response = Enumerable.Range(1, 1).Select(index => new Student
            {
                Address = "Taxus USA",
                GraduationYear = 2020,
                Name = "Adam"
            }).ToArray();
            logger.LogDebug("Inside GetStudent endpoint");
            logger.LogDebug($"The response for the GetStudent is {JsonConvert.SerializeObject(response)}");
            return response;
        }
    }
}
