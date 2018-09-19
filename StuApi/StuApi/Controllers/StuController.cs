using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using StuApi.Models;
using System.Linq;
namespace StuApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StuController : ControllerBase
    {
        private IData _database;

        public StuController(IData data)
        {
            _database = data;
        }

        [HttpGet]
        public ActionResult<List<Student>> GetAll()
        {
            return _database.GetAllStudents();
        }

        [HttpGet("{id}", Name = "GetStudent")]
        public ActionResult<Student> GetById(int id)
        {
            var student = _database.GetStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return student;
        }

        [HttpGet]
        [Route("range")]
        public ActionResult<float[]> GetRange() 
        {
            List<float> listOfGpas= new List<float>();
            float[] listOfGpasToReturn = new float[2];

            _database.GetAllStudents().ForEach((student) => listOfGpas.Add(student.StudentGpa));

            listOfGpas.Sort();
            listOfGpasToReturn[0] = listOfGpas.First<float>();
            listOfGpasToReturn[1] = listOfGpas.Last<float>();

            return listOfGpasToReturn;
        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            _database.CreateStudent(student);
            _database.SaveChanges();

            return CreatedAtRoute("GetStudent", new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Student student)
        {
            var stu = _database.GetStudent(id);
            if (stu == null)
            {
                return NotFound();
            }

            _database.UpdateStudent(student);
            _database.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var stu = _database.GetStudent(id);
            if (stu == null)
            {
                return NotFound();
            }

            _database.DeleteStudent(stu);
            _database.SaveChanges();
            return NoContent();
        }

    }
}
