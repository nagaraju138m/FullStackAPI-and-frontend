using Repository.Interfaces;
using SampleData;
using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class StudnetRepository : GenericRepository<Student>, IStudnetRepository
    {
        public StudnetRepository(StudendDbcontext context) : base(context)
        {
        }
    }
}
