using AutoMapper;
using DataAccess.Entity;
using DTO.EntityDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Config
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<AboutDTO, About>();
            CreateMap<About, AboutDTO>();

            CreateMap<CategoryDTO, Category>();
            CreateMap<Category, CategoryDTO>();

            CreateMap<ContactDTO, Contact>();
            CreateMap<Contact, ContactDTO>();

            CreateMap<MessageDTO, Message>();
            CreateMap<Message, MessageDTO>();

            CreateMap<ProductDTO, Product>();
            CreateMap<Product, ProductDTO>();

            CreateMap<UserDTO, User>();
            CreateMap<User, UserDTO>();
        }

    }
}
