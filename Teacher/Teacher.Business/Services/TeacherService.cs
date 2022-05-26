using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Data.Repositories;
using Teacher.Entity;

namespace Teacher.Business.Services
{
    public class TeacherService
    {
        ITeacher _teacher;

        public TeacherService(ITeacher teacher)
        {
            _teacher = teacher; 
        }

        public string Register(Entity.Master master)
        { 
            return _teacher.Register(master);
        }

        public object ShowAllTeacher()
        { 
            return _teacher.ShowAllTeacher();
        }

    }

}
