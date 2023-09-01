using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using SampleData;
using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SampleData.Data.GetAllStudentBooks;

namespace Repository.Repository
{
    public class StudnetRepository : GenericRepository<Student>, IStudnetRepository
    {
        private readonly StudendDbcontext context;

        public StudnetRepository(StudendDbcontext context) : base(context)
        {
            this.context = context;
        }
        public async Task<StudentsBooks> AddSbooks(StudentsBooks entity)
        {
            var books = await context.studentsBooks.AddAsync(entity);
            await context.SaveChangesAsync();

            return (entity);
        }

        public async Task<IEnumerable<GetAllStudentBooks>> allSbooks()
        {
            var Sbooks = await (from student in context.student
                                join sbooks in context.studentsBooks on student.Id equals sbooks.studentId
                                join btype in context.bookTypes on sbooks.bookId equals btype.bookTypeId
                                join book in context.books on btype.bookTypeId equals book.bookTypeId
                                where sbooks.bookId == book.bookTypeId
                                select new
                                {
                                    student.Id,
                                    student.Name,
                                    student.City,
                                    student.Mobile,
                                    book.BookName,
                                    book.Active,
                                    btype.booksType,
                                    book.description,
                                    btype.bookTypeId
                                })
                    .Distinct() // Ensures unique rows
                    .GroupBy(s => new { s.Id, s.Name, s.City, s.Mobile })
                    .Select(g => new GetAllStudentBooks
                    {
                        StudentId = g.Key.Id,
                        StudentName = g.Key.Name,
                        City = g.Key.City,
                        MobileNo = g.Key.Mobile,
                        Book = g.Select(s => new BookInfo
                        {
                            BookName = s.BookName,
                            Active = s.Active,
                            BooksType = s.booksType,
                            BookTypeDescripting = s.description,
                            BtypeId = s.bookTypeId
                        }).ToList()
                    })
                    .ToListAsync();

            //var Sbooks = await (from student in context.student
            //                    join sbooks in context.studentsBooks on student.Id equals sbooks.studentId
            //                    join btype in context.bookTypes on sbooks.bookId equals btype.bookTypeId
            //                    join book in context.books on btype.bookTypeId equals book.bookTypeId
            //                    select new GetAllStudentBooks
            //                    {
            //                        StudentId = student.Id,
            //                        StudentName = student.Name,
            //                        City = student.City,
            //                        MobileNo = student.Mobile,
            //                        BookName = book.BookName,
            //                        Active = book.Active,
            //                        BooksType = btype.booksType,
            //                        BookTypeDescripting = book.description
            //                    }).ToListAsync();

            return Sbooks;

        }
    }
}

