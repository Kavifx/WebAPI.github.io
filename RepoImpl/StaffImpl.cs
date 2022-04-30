using WebAPI.DTO;
using WebAPI.Models;
using WebAPI.RepoInterfaces;

namespace WebAPI.RepoImpl
{
    internal class StaffImpl : IStaffRepo
    {
        private AppDbContext ctx;

        public StaffImpl(AppDbContext db)
        {
            ctx = db;
        }

        public bool AddStaff(StaffDTO staff)
        {
            Staff staff1 = new Staff()
            {
                StaffName = staff.StaffName,
                DOJ = Convert.ToDateTime(staff.DOJ).Date.ToShortDateString()
            };
            
            ctx.Staffs.Add(staff1);
            ctx.SaveChanges();
            return true;
        }

        public bool DeleteStaff(int id)
        {
            var selStaff = (from obj in ctx.Staffs
                            where obj.StaffId == id
                            select obj).FirstOrDefault();
            if(selStaff != null)
            {
                ctx.Staffs.Remove(selStaff);
                ctx.SaveChanges();
                return true;
            }

            return false;
        }

        public List<StaffDTO> GetAll()
        {
            List<StaffDTO> staff = (from obj in ctx.Staffs
                                    select new StaffDTO()
                                    {
                                        StaffID = obj.StaffId,
                                        StaffName = obj.StaffName,
                                        DOJ = Convert.ToDateTime(obj.DOJ).Date.ToShortDateString()
                                    }).ToList();
            return staff;
        }

        public StaffDTO GetById(int id)
        {
            var staff = (from obj in ctx.Staffs
                         where obj.StaffId == id
                         select new StaffDTO
                         {
                             StaffID = obj.StaffId,
                             StaffName = obj.StaffName,
                             DOJ = Convert.ToDateTime(obj.DOJ).Date.ToShortDateString()
                         }).FirstOrDefault();
            return staff;
        }

        public bool UpdateStaff(StaffDTO staff)
        {
            var selStaff = (from obj in ctx.Staffs
                            where obj.StaffId == staff.StaffID
                            select obj).FirstOrDefault();
            if (selStaff != null)
            { 
                ctx.SaveChanges();
                return true;
            }

            return false;
        }
    }
}