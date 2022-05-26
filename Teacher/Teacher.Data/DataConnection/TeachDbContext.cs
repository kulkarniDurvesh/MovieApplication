using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teacher.Entity;

namespace Teacher.Data.DataConnection
{
    public class TeachDbContext: DbContext
    {
        public TeachDbContext(DbContextOptions<TeachDbContext>options):base(options)
        {

        }

        public DbSet<Master> masters { get; set; }
        

    }
}
