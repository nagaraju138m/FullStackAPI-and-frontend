using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.Data
{
    public class bookType
    {
        [Key]
        public int bookTypeId { get; set; }
        public string booksType { get; set; }
        public string bookTypeDescription { get; set;}
        public ICollection<Book> books { get; set; }
    }
}
