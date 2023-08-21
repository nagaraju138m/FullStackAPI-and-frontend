using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.Data
{
    public class StudentPayments
    {
        [Key]
        public int Id { get; set; }
        public int studentId { get; set; }
        public double TotalAmount { get; set; }
        public double PaidAmount { get; set; }
        public string AmountReceivedBy { get; set; }

    }
}
