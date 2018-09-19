using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
namespace StuApi.Models
{
    public class Data: IData
    {
        const string databasePath = "databasefile.csv";
        List<Student> listOfStudents;

        public Data()
        {
            listOfStudents = new List<Student>();
            LoadFile();
        }

        public Student GetStudent(int id)
        {
            return listOfStudents.Find((Student stu) => stu.Id == (id.ToString()));

        }

        public List<Student> GetAllStudents() 
        {
            return listOfStudents;
        }

        public void CreateStudent(Student stu)
        {
            listOfStudents.Add(stu);
        }

        public void UpdateStudent(Student updatedStudent)
        {
            Student currentStudent = listOfStudents.Find((Student stu) => stu.Id == updatedStudent.Id);
            DeleteStudent(currentStudent);
            CreateStudent(updatedStudent);
        }

        public void DeleteStudent(Student deleteStudent)
        {
            listOfStudents.Remove(deleteStudent);
        }

        private void LoadFile()
        {
            StreamReader sr = new StreamReader(databasePath);
            string currentLine;

            while ((currentLine = sr.ReadLine()) != null)
            {
                string[] studentLine = currentLine.Split(',');
                this.listOfStudents.Add(new Student { Id = studentLine[0], StudentName = studentLine[1], StudentGpa = float.Parse(studentLine[2]) });
            }

            sr.Close();
        }

        public void SaveChanges()
        {
            Student[] toWriteStudent = listOfStudents.ToArray();
            string[] toWriteString = Array.ConvertAll(toWriteStudent, stu => stu.ToString());

            File.WriteAllLines(databasePath, toWriteString);

        }


    }

}
