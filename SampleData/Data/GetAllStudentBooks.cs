using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.Data
{
    public class GetAllStudentBooks
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string City { get; set; }
        public int MobileNo { get; set; }
        public List<BookInfo> Book { get; set; }

        public class BookInfo
        {
            public string BookName { get; set; }
            public bool Active { get; set; }
            public int BooksType { get; set; }
            public string BookTypeDescripting { get; set; }
            public int BtypeId { get; set; }
        }
    }
}
