﻿using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IBookRepository : IGenericRepository<Book>
    {
        Task<IEnumerable<GetAllBookDetails>> GetAllbooks();
        Task<List<Book>> GetbooksById(int id);
    }
}
