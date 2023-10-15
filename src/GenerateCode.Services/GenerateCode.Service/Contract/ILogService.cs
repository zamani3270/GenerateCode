using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Service
{
    public interface ILogService
    {
        void InsertUrlRequestedCount(string content, bool isUrlRequested);
        int? GetContentSerachCount(string content);
    }
}
