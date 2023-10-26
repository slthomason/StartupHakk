using WEBAPIDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEBAPIDemo
{
    public interface IStudentRespository
    {
        ActionResult<IEnumerable<Student>> Get();

        Task Post(Student student);

        Task Update(Student student);

        Task Delete(int? id);
    }
}
