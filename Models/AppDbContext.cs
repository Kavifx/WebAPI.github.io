using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opts) : base(opts)
        {

        }
        
        public DbSet<Semester> Semesters { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Student> Students { get; set; }
    }

    public class Semester
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string SemName { get; set; }
    }

    public class Department
    {
        [Key]
        public int DeptId { get; set; }

        [Required]
        public string DeptName { get; set; }
    }

    public class Staff
    {
        [Key]
        public int StaffId { get; set; }

        [Required]
        public string StaffName { get; set; }

        [Required]
        public string DOJ { get; set; }

        //Navigation Prop
        public List<Student> Students { get; set; }
    }

    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string DOB { get; set; }
        public int DeptId { get; set; }
        public int StaffId { get; set; }

        //Navigation Prop

        [ForeignKey("DeptId")]
        public Department AssignedDept { get; set; }

        [ForeignKey("StaffId")]
        public Staff AssignedStaff { get; set; }
    }
}
