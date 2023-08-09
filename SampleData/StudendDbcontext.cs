using Microsoft.EntityFrameworkCore;
using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData
{
    public class StudendDbcontext : DbContext
    {
        public StudendDbcontext(DbContextOptions options) : base(options)
        { 

        }

        public DbSet<Student> student { get; set; }
    }
    
}



