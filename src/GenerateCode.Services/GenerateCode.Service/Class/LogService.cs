using GenerateCode.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Service
{
    public class LogService:ILogService
    {
        #region CTOR
        private readonly ILogRepository _logRepository;
        public LogService(ILogRepository logRepository)
        {
            _logRepository = logRepository;
        }
        #endregion CTOR
       
        #region Methods
        public int? GetContentSerachCount(string content)
        {
           return _logRepository.GetContentSerachCount(content);
        }
        public void InsertUrlRequestedCount(string content, bool isUrlRequested)
        {
            _logRepository.InsertUrlRequestedCount(content, isUrlRequested);
        }
        #endregion Methods
    }
}
