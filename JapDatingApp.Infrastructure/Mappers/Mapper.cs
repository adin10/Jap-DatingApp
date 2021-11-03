using AutoMapper;
using JapDatingApp.Database;
using JapDatingApp.Infrastructure.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JapDatingApp.Infrastructure.Mappers
{
   public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<AppUser, MemberDto>().ReverseMap();
            CreateMap<AppUser, MemberDto>().ForMember(dest=>dest.PhotoUrl,opt=>opt.MapFrom(src=>
                                            src.Photos.FirstOrDefault(x=>x.IsMain).Url));
            CreateMap<Photo, PhotoDto>();
        }
    }
}
