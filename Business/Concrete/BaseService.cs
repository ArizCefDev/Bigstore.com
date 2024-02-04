using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class BaseService<RqDTO, T, RsDTO> : IBaseService<RqDTO, T, RsDTO>
        where T : class
    {
        protected readonly IMapper _mapper;
        protected readonly AppDBContext _dBContext;
        protected readonly DbSet<T> _dBSet;

        public BaseService(IMapper mapper, AppDBContext dBContext)
        {
            _mapper = mapper;
            _dBContext = dBContext;
            _dBSet = dBContext.Set<T>();
        }

        public void Delete(int id)
        {
            var ent = _dBSet.Find(id);
            _dBSet.Remove(ent);
            _dBContext.SaveChanges();
        }

        public List<RsDTO> GetAll()
        {
            var ent = _dBSet.ToList();
            var rsdto = _mapper.Map<List<RsDTO>>(ent);
            return rsdto;
        }

        public RsDTO GetById(int id)
        {
            var ent = _dBSet.Find(id);
            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public RsDTO Insert(RqDTO dto)
        {
            var ent = _mapper.Map<T>(dto);

            _dBSet.Add(ent);
            _dBContext.SaveChanges();

            var rsdto = _mapper.Map<RsDTO>(ent);
            return rsdto;
        }

        public void Update(RqDTO dto)
        {
            var ent = _mapper.Map<T>(dto);
            _dBSet.Update(ent);
            _dBContext.SaveChanges();
        }
    }
}
