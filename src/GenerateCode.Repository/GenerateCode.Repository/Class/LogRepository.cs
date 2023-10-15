using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenerateCode.Repository
{
    public class LogRepository : ILogRepository
    {
        #region CTOR
        private readonly ApplicationDbContext _context;
        public LogRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        #endregion CTOR

        #region Methods
        public void InsertUrlRequestedCount(string content, bool isUrlRequested)
        {
            var recordExist = _context.RequestLog.OrderByDescending(o=> o.Id).
                                                  Where(item => item.RequestContent == content &&
                                                                item.IsURLRequested==isUrlRequested).FirstOrDefault();
            if (recordExist == null)
            {
                _context.RequestLog.Add(new Data.RequestLog
                {
                    IsURLRequested = isUrlRequested,
                    RequestContent = content,
                    RequestCount = 1
                });
            }
            else
            {
                recordExist.RequestCount++;
                _context.RequestLog.Attach(recordExist);
            }
            _context.SaveChanges();
           
        }
        public int? GetContentSerachCount(string content)
        {
            return _context.RequestLog.FirstOrDefault(item => item.RequestContent == content)?.RequestCount;
        }
        #endregion Methods
    }
}
