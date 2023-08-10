using AutoMapper;
using SampleData.CustomModals;
using SampleData.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleData
{
    public class AutoMappers : Profile
    {
        public AutoMappers()
        {
            CreateMap<Student, GetStudentsDto>().ReverseMap();
        }
    }
}
