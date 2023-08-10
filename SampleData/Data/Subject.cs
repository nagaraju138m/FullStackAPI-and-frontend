namespace SampleData.Data
{
    public class Subject
    {
        
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public ICollection<GroupSubject> GroupSubjects { get; set; }
    }

}
