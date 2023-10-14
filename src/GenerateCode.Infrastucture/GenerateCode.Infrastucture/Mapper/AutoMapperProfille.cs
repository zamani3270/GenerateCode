using AutoMapper;
using GenerateCode.Data;
using GenerateCode.Infrastucture.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Infrastucture
{
    public class AutoMapperProfille: Profile
    {
        public AutoMapperProfille()
        {
            CreateMap<URLInfo, URLInfoDTO>();
            CreateMap<URLInfo, URLInfoDTO>().ReverseMap();
        }
    }
}
