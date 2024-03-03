using AutoMapper;
using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entity;
using DTO.EntityDTO;
using Helper;
using Helper.CryptoFile;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
	public class UserService : BaseService<UserDTO, User, UserDTO>, IUserService
	{
		public UserService(IMapper mapper, AppDBContext dbContext)
			: base(mapper, dbContext)
		{
		}
	
		public override UserDTO Insert(UserDTO dto)
		{
			var res = _dBContext.Users.Where(x => x.Username == dto.Username);

			var role = _dBContext.Roles.Where(x => x.Name == RoleKeywords.UserRole)?.First();
			dto.RoleID = role.ID;

			if (res.Any())
			{
				throw new Exception("Bu istifadəçi adı mövcuddur!");
			}

			dto.Salt = Crypto.GenerateSalt();
			dto.PasswordHash = Crypto.GenerateSHA256Hash(dto.Password, dto.Salt);
			return base.Insert(dto);
		}

		public UserDTO Login(UserDTO p)
		{
			var res = _dBContext.Users
			.Where(x => x.Username == p.Username)
			 .Include(u => u.Role);

			if (res.Count() == 1)
			{
				var user = res.FirstOrDefault();

				var hash = Crypto.GenerateSHA256Hash(p.Password, user.Salt);

				if (hash == user.PasswordHash)
				{
					var dto = _mapper.Map<User, UserDTO>(res.First());
					return dto;
				}
				else
				{
					throw new Exception("Şifrə yalnışdır!");
				}
			}
			else
			{
				throw new Exception("Hesab mövcud deyil");
			}
		}
	}
}
