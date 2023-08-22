using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.Data
{
    public class StudentsBooks
    {
        [Key]
        public int Id { get; set; } 
        public int studentId { get; set; }
        [ForeignKey("bookId")]
        public int bookId { get; set; }
        public Book book { get; set; }
        public bool hasBook { get; set; }
    }
}
