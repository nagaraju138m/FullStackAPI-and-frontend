using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SampleData.Data.GetAllStudentBooks;

namespace SampleData.Data
{
    public class StuPayments
    {
        public int Id { get; set; }
        public int studentId { get; set; }
        public double TotalAmount { get; set; }
        public List<transactions> Transactions { get; set; }
    }
    public class transactions
    {
        public double PaidAmount { get; set; }
        public string AmountReceivedBy { get; set; }
        public DateTime PadiDate { get; set; }
    }
}
