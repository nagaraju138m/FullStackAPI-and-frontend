using Repository.Interfaces;
using SampleData;
using SampleData.Data;
using System;
using System.Collections.Generic;
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





    }
}
