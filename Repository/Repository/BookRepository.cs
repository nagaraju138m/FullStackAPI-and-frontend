using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using SampleData;
using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class BookRepository : GenericRepository<Book>, IBookRepository
    {
        private readonly StudendDbcontext context;

        public BookRepository(StudendDbcontext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<GetAllBookDetails>> GetAllbooks()
        {
            List<GetAllBookDetails> allbookds = new List<GetAllBookDetails>();
            allbookds = await (from book in context.books
                               join btype in context.bookTypes on book.bookTypeId equals btype.bookTypeId
                               select new GetAllBookDetails
                               {
                                   bookId = book.bookId,
                                   booksType = btype.booksType,
                                   BookName = book.BookName,
                                   description = book.description,
                                   price = book.price,
                                   quantity = book.quantity,
                                   Active = book.Active
                               }).ToListAsync();
            if (allbookds.Count > 0)
            {
                string strMessage = "success";
            }
            return (allbookds);
        }

        public async Task<List<Book>> GetbooksById(int id)
        {
            var books = await context.books.Where(b => b.bookTypeId == id).ToListAsync() ;
            return books;
        }
    }
}
