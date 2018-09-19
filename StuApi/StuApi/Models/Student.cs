using System;
namespace StuApi.Models
{
    public class Student
    {
        public string Id { get; set; }
        public string StudentName { get; set; }
        public float StudentGpa { get; set; }


        public override string ToString() 
        {
            return Id + "," + StudentName + "," + StudentGpa + ",";
        }

    }
}
