using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData.Data
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public int Mobile { get; set; }


        [ForeignKey(nameof(GroupId))]
        public int GroupId { get; set; } // Foreign key
        public Group Group { get; set; } // Navigation property
    }
}
