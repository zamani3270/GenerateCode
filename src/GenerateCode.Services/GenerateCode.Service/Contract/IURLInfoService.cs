using GenerateCode.Infrastucture;
using GenerateCode.Infrastucture.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Service
{
    public interface IURLInfoService
    {
        ResultItem<URLInfoDTO> PrepareURLInfoByCode(Guid code);
        URLInfoDTO PrepareURLInfoByURL(string url);
    }
}
