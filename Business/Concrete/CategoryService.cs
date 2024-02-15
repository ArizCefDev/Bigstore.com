using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryService
        : BaseService<CategoryDTO, Category, CategoryDTO>, ICategoryService
    {
        public CategoryService(IMapper mapper, AppDBContext dBContext) : base(mapper, dBContext)
        {
        }
    }
}
