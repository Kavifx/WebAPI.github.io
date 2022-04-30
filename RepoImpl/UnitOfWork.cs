using WebAPI.Models;
using WebAPI.RepoInterfaces;

namespace WebAPI.RepoImpl
{
    public class IUnitOfWorK : IUnitofWorK
    {       
        AppDbContext ctx;
        public IUnitOfWorK(AppDbContext db)
        {
            ctx = db;
        }      

        IDepartmentRepo IUnitofWorK.DepartmentRepo => new DepartmentImpl(ctx);

        ISemesterRepo IUnitofWorK.SemesterRepo => new SemesterImpl(ctx);

        IStudentRepo IUnitofWorK.StudentRepo => new StudentImpl(ctx);

        IStaffRepo IUnitofWorK.StaffRepo => new StaffImpl(ctx);
    }
}
