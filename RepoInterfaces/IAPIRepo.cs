using WebAPI.DTO;

namespace WebAPI.RepoInterfaces
{
    public interface IDepartmentRepo
    {
        List<DepartmentDTO> GetAll();
        DepartmentDTO GetById(int id);
        bool AddDept(DepartmentDTO dept);
        bool UpdateDept(DepartmentDTO dept);
        bool DeleteDept(int id);
    }

    public interface ISemesterRepo
    {
        List<SemesterDTO> GetAll();
        SemesterDTO GetById(int id);
        bool AddSemester(SemesterDTO semester);
        bool UpdateSemester(SemesterDTO semester);
        bool DeleteSemester(int id);
    }

    public interface IStaffRepo
    {
        List<StaffDTO> GetAll();
        StaffDTO GetById(int id);
        bool AddStaff(StaffDTO staff);
        bool UpdateStaff(StaffDTO staff);
        bool DeleteStaff(int id);
    }

    public interface IStudentRepo
    {
        List<StudentDTO> GetAll();
        StudentDTO GetById(int id);
        bool AddStudent(StudentDTO student);
        bool UpdateStudent(StudentDTO student);
        bool DeleteStudent(int id);
    }
}
