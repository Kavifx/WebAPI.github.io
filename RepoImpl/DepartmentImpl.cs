using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.RepoInterfaces;

namespace WebAPI.RepoImpl
{
    public class DepartmentImpl : IDepartmentRepo
    {
        AppDbContext ctx;
        public DepartmentImpl(AppDbContext db)
        {
            ctx = db;
        }
        public bool AddDept(DepartmentDTO dept)
        {
            Department department = new Department();            
            department.DeptName = dept.DepartmentName;
            ctx.Department.Add(department);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteDept(int id)
        {
            var selDept = (from obj in ctx.Department
                          where obj.DeptId == id
                          select obj).FirstOrDefault();
            if (selDept != null)
            {
                ctx.Department.Remove(selDept);
                ctx.SaveChanges();
                return true;
            }

            return false;
        }

        public List<DepartmentDTO> GetAll()
        {
            List<DepartmentDTO> depts = (from obj in ctx.Department
                                         select new DepartmentDTO
                                         {
                                             DepartmentID = obj.DeptId,
                                             DepartmentName = obj.DeptName
                                         }).ToList();
            return depts;
        }

        public DepartmentDTO GetById(int id)
        {
            var Dept = (from obj in ctx.Department
                         where obj.DeptId == id
                         select new DepartmentDTO
                         {
                             DepartmentID = obj.DeptId,
                             DepartmentName = obj.DeptName
                         }).FirstOrDefault();
            return Dept;
        }

        public bool UpdateDept(DepartmentDTO dept)
        {
            var selDept = (from obj in ctx.Department
                           where obj.DeptId == dept.DepartmentID
                           select obj).FirstOrDefault();
            if(selDept != null)
            {
                selDept.DeptId = dept.DepartmentID;
                selDept.DeptName = dept.DepartmentName;
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
