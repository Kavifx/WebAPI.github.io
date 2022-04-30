namespace WebAPI.RepoInterfaces
{
    public interface IUnitofWorK
    {
        IDepartmentRepo DepartmentRepo { get; }
        ISemesterRepo SemesterRepo { get; }
        IStudentRepo StudentRepo { get; }
        IStaffRepo StaffRepo { get; }
    }
}
