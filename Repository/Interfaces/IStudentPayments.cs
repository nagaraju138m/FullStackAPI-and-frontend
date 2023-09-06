using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStudentPayments : IGenericRepository<StudentPayments>
    {
        Task<IEnumerable<StuPayments>> GetStuPayment(int id);
    }
}
