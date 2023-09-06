using Microsoft.EntityFrameworkCore;
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
    public class StudentPaymentsRepo : GenericRepository<StudentPayments>, IStudentPayments
    {
        private readonly StudendDbcontext context;

        public StudentPaymentsRepo(StudendDbcontext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<StuPayments>> GetStuPayment(int id)
        {
            var payments = await context.studentPayments
            .Where(sp => sp.studentId == id)
            .ToListAsync();

            var stuPayments = payments.GroupBy(sp => sp.studentId)
            .Select(g => new StuPayments
            {
                studentId = g.Key,
                TotalAmount = g.Sum(t => t.TotalAmount),
                Transactions = g.Select(t => new transactions
                {
                    PaidAmount = t.PaidAmount,
                    AmountReceivedBy = t.AmountReceivedBy,
                    PadiDate = t.PadiDate
                }).ToList()
            })
            .ToList();

            return stuPayments;
        }
    }
}
