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
            // Check if the student already has the book
            var existingBooks = await context.studentsBooks
                .Where(s => s.studentId == entity.studentId && s.bookId == entity.bookId)
                .ToListAsync();

            if (existingBooks.Count > 0)
            {
                throw new Exception("The student already has the book.");
            }
            await context.SaveChangesAsync();

            return (entity);
        }

        public async Task<IEnumerable<GetAllStudentBooks>> allSbooks()
        {
            var Sbooks = await (from sbooks in context.studentsBooks
                                join student in context.student on sbooks.studentId equals student.Id
                                join book in context.books on sbooks.bookId equals book.bookId
                                join btype in context.bookTypes on book.bookTypeId equals btype.bookTypeId   
                                select new
                                {
                                    student.Id,
                                    student.Name,
                                    student.City,
                                    student.Mobile,
                                    sbooks.bookId,
                                    book.BookName,
                                    book.Active,
                                    book.description,
                                    book.bookTypeId

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
                            BookTypeDescripting = s.description,
                            BtypeId = s.bookTypeId,
                            BooksType = s.bookId,
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

