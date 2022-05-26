using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Data.DataConnection;
using Teacher.Entity;

namespace Teacher.Data.Repositories
{
    public class Master : ITeacher
    {
        TeachDbContext _teachDbContext;

        public Master(TeachDbContext teachDbContext)
        {
                _teachDbContext = teachDbContext;
        }
        public string Register(Entity.Master master)
        {
            string msg = "";
            _teachDbContext.masters.Add(master);
            _teachDbContext.SaveChanges();
            msg = "Registered Successfully";
            return msg;
        }

        public object ShowAllTeacher()
        {
            List<Entity.Master> teacherList = _teachDbContext.masters.ToList(); 
            return teacherList;
        }
    }
}
