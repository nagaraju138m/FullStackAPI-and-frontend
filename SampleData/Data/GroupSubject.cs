using System.ComponentModel.DataAnnotations;

namespace SampleData.Data
{
    public class GroupSubject
    {
        [Key]
        public int GroupId { get; set; }
        public Group Group { get; set; }
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
    }

}
