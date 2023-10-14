using GenerateCode.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Repository
{
    public interface IURLInfoRepository
    {
        bool SaveObject(URLInfo dataModel);
        URLInfo GetInfoByURL(string url);
        URLInfo? GetInfoByCode(Guid code);
    }
}
