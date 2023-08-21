using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.Data
{
    public class Book
    {
        [Key]
        public int bookId {  get; set; }
        [ForeignKey("bookTypeId")]
        public int bookTypeId { get; set; }
        public string BookName { get; set; }
        public string description { get; set; }
        public double price { get; set; }
        public int quantity { get; set; }
        public bool Active { get; set; }

    }
}
