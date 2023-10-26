using WEBAPIDemo.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using WEBAPIDemo.Models;

namespace WEBAPIDemo.Respostories
{
    public class StudentRepository : IStudentRespository
    {
        private MainContext _mainContext;
        public StudentRepository(MainContext context)
        {
            _mainContext = context;
        }

        public ActionResult<IEnumerable<Student>> Get()
        {
            var stud =  _mainContext.Students.ToList();
            return stud;
        }

        public async Task Post(Student student)
        {
            if(student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            await _mainContext.Students.AddAsync(student);
            await _mainContext.SaveChangesAsync();

        }

        public async Task Update(Student student)
        {
            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            Student existingStudent = _mainContext.Students.FirstOrDefault(s => s.StudentId == student.StudentId);

            if (existingStudent == null)
            {
                throw new ArgumentNullException(nameof(existingStudent));
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.MobileNumber = student.MobileNumber;
            existingStudent.City = student.City;
            existingStudent.Email = student.Email;

            _mainContext.Attach(existingStudent).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _mainContext.SaveChangesAsync();

        }

        public async Task Delete(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id));
            }

            Student student = _mainContext.Students.FirstOrDefault(s => s.StudentId == id);

            if (student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _mainContext.Students.Remove(student);
            await _mainContext.SaveChangesAsync();
        }



        
    }
}
