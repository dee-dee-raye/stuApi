using System;
using System.Collections.Generic;
namespace StuApi.Models
{
    public interface IData
    {
        Student GetStudent(int id);

        List<Student> GetAllStudents();

        void CreateStudent(Student stu);

        void UpdateStudent(Student updatedStudent);

        void DeleteStudent(Student deleteStudent);

        void SaveChanges();

    }
}
