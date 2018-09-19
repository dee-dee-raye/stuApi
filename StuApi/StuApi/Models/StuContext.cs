using Microsoft.EntityFrameworkCore;

namespace StuApi.Models
{
    public class StuContext: DbContext
    {
        public StuContext(DbContextOptions<StuContext> options) : base(options)
        {
            //dataLayer.GetAllStudents().ForEach((Student stu) => Students.Add(stu));
        }

        public DbSet<Student> Students { get; set; }
    }
}
