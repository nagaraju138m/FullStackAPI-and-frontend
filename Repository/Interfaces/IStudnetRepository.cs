﻿using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interfaces
{
    public interface IStudnetRepository : IGenericRepository<Student>
    {
        Task<StudentsBooks> AddSbooks(StudentsBooks entity);
        Task<IEnumerable<GetAllStudentBooks>> allSbooks();
    }

}
