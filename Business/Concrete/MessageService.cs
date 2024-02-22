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
    public class MessageService
        : BaseService<MessageDTO, Message, MessageDTO>, IMessageService
    {
        public MessageService(IMapper mapper, AppDBContext dBContext) 
            : base(mapper, dBContext)
        {
        }
    }
}
