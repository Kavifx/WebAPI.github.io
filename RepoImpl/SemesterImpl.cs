using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.RepoInterfaces;

namespace WebAPI.RepoImpl
{
    public class SemesterImpl : ISemesterRepo
    {
        private AppDbContext ctx;

        public SemesterImpl(AppDbContext db)
        {
            ctx = db;
        }

        public bool AddSemester(SemesterDTO semester)
        {
            Semester sem = new Semester()
            {
                Id = semester.SemesterID,
                SemName = semester.SemesterName
            };
            ctx.Semesters.Add(sem);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteSemester(int id)
        {
            var selSem = (from obj in ctx.Semesters
                          where obj.Id == id
                          select obj).FirstOrDefault(); 
            if(selSem != null)
            {
                ctx.Semesters.Remove(selSem);
                ctx.SaveChanges();
                return true;
            }
            return false;
        }

        public List<SemesterDTO> GetAll()
        {
            List<SemesterDTO> sems = (from obj in ctx.Semesters
                                      select new SemesterDTO() 
                                      { 
                                          SemesterID = obj.Id,
                                          SemesterName = obj.SemName
                                      }).ToList();
            return sems;
        }

        public SemesterDTO GetById(int id)
        {
            var sem = (from obj in ctx.Semesters
                       where obj.Id == id
                       select new SemesterDTO()
                       {
                           SemesterID = obj.Id,
                           SemesterName = obj.SemName
                       }).FirstOrDefault();
            return sem;
        }

        public bool UpdateSemester(SemesterDTO semester)
        {
            var selSem = (from obj in ctx.Semesters
                          where obj.Id == semester.SemesterID
                          select obj).FirstOrDefault();
            if (selSem != null)
            {
                selSem.Id = semester.SemesterID;
                selSem.SemName = semester.SemesterName;
                ctx.SaveChanges();
                return true;
            }
            return false;
        }
    }
}