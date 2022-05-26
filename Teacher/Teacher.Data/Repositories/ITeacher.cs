using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Entity;
namespace Teacher.Data.Repositories
{
    public interface ITeacher
    {
        string Register(Entity.Master master);

        object ShowAllTeacher();
    }
}
