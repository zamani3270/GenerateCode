using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Repository
{
    public interface ILogRepository
    {
        int? GetContentSerachCount(string content);
        void InsertUrlRequestedCount(string content, bool isUrlRequested);
    }
}
