namespace WebAPI.DTO
{
    public class SemesterDTO
    {
        public int SemesterID { get; set; }
        public string SemesterName { get; set; }
    }

    public class DepartmentDTO
    {
        public int DepartmentID { get; set; }
        public string DepartmentName { get; set; }  
    }

    public class StaffDTO
    {
        public int StaffID { get; set; }
        public string StaffName { get; set; }
        public string DOJ { get; set; }
    }

    public class StudentDTO
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string DOB { get; set; }
        public int DeptId { get; set; }
        public int StaffId { get; set; }
    }

}
