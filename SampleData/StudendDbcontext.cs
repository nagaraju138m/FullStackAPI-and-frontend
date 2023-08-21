using Microsoft.EntityFrameworkCore;
using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData
{
    public class StudendDbcontext : DbContext
    {
        public StudendDbcontext(DbContextOptions options) : base(options)
        { 

        }

        public DbSet<Student> student { get; set; }
        public DbSet<Group> groups { get; set; }
        public DbSet<Subject> subjects { get; set; }
        public DbSet<GroupSubject> groupsSubject { get; set; }
        public DbSet<Book> books { get; set; }
        public DbSet<bookType> bookTypes { get; set; }
        public DbSet<StudentsBooks> studentsBooks { get; set; }
        public DbSet<StudentPayments> studentPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>()
                .HasOne(s => s.Group)
                .WithMany(g => g.students)
                .HasForeignKey(s => s.GroupId);
        }
    }
    
}



