using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.RepoInterfaces;

namespace WebAPI.RepoImpl
{
    internal class StudentImpl : IStudentRepo
    {
        private AppDbContext ctx;
        private IStudentRepo studentRepo;
        public StudentImpl(AppDbContext db)
        {
            ctx = db;
            studentRepo = new StudentImpl(ctx);
        }

        public bool AddStudent(StudentDTO student)
        {
            Student studentToUpdate = new Student()
            {
                StudentId = student.StudentID,
                StudentName = student.StudentName,
                DOB = Convert.ToDateTime(student.DOB).Date.ToShortDateString(),
                DeptId = student.DeptId,
                StaffId = student.StaffId
            };
            ctx.Students.Add(studentToUpdate);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var selStudent = (from obj in ctx.Students
                           where obj.StudentId == id
                           select obj).FirstOrDefault();

            if(selStudent != null)
            {
                ctx.Students.Remove(selStudent);
                ctx.SaveChanges();
                return true;
            }

            return false;
        }

        public List<StudentDTO> GetAll()
        {
            List<StudentDTO> students = (from obj in ctx.Students
                                         select new StudentDTO()
                                         {
                                             StudentID = obj.StudentId,
                                             StudentName = obj.StudentName,
                                             DOB = Convert.ToDateTime(obj.DOB).Date.ToShortDateString(),
                                             DeptId = obj.DeptId,
                                             StaffId = obj.StaffId
                                         }).ToList();
            return students;
        }

        public StudentDTO GetById(int id)
        {
            var students = (from obj in ctx.Students
                            where obj.StudentId == id
                            select new StudentDTO()
                            {
                                StudentID = obj.StudentId,
                                StudentName = obj.StudentName,
                                DOB = Convert.ToDateTime(obj.DOB).Date.ToShortDateString(),
                                DeptId = obj.DeptId,
                                StaffId = obj.StaffId
                            }).FirstOrDefault();
            return students;
        }

        public bool UpdateStudent(StudentDTO student)
        {
            var selStudent = (from obj in ctx.Students
                              where obj.StudentId == student.StudentID
                              select obj).FirstOrDefault();

            if (selStudent != null)
            {
                selStudent.StudentName = student.StudentName;
                selStudent.DOB = Convert.ToDateTime(student.DOB).Date.ToShortDateString();
                selStudent.DeptId = student.DeptId;
                selStudent.StaffId = student.StaffId;
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}